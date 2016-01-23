using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace jcPVS.Library {
    public class jcPVSMediaFormatter : MediaTypeFormatter {
        public jcPVSMediaFormatter() {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

        readonly Func<Type, bool> _supportedType = (type) => true;

        public override bool CanReadType(Type type) {
            return _supportedType(type);
        }

        public override bool CanWriteType(Type type) {
            return _supportedType(type);
        }
        
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext)
        {
            return Task.Factory.StartNew(() =>
            {
                BuildObject(value, writeStream,
                    content.Headers.ContentType.MediaType,
                    Convert.ToInt32(content.Headers.GetValues(Constants.API_KEY).FirstOrDefault()));
            });

        }

        private static void BuildObject(object obj, Stream stream, string contenttype, int apiVersion) {
            var type = obj.GetType();
            var properties = type.GetProperties();

            var attrs = System.Attribute.GetCustomAttributes(type);
            
            using (var streamWriter = new StreamWriter(stream)) {
                using (var writer = new JsonTextWriter(streamWriter)) {
                    writer.WriteStartObject();

                    foreach (var property in properties) {
                        var includeProperty = true;

                        foreach (var attr in property.GetCustomAttributes(false)) {
                            var attribute = attr as jcPVSAttribute;

                            if (attribute != null && attribute?.GetMinAPIVersion() >= apiVersion)  {
                                includeProperty = false;
                                continue;
                            }
                        }

                        if (!includeProperty) {
                            continue;
                        }

                        writer.WritePropertyName(property.Name);
                        writer.WriteValue(property.GetValue(obj));
                    }

                    writer.WriteEndObject();
                }
            }
        }
    }
}