﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace jcPVS.Library {
    public class jcPVSMediaFormatter : MediaTypeFormatter {
        private const string json = "application/json";

        public jcPVSMediaFormatter() {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue(json));
        }

        readonly Func<Type, bool> _supportedType = (type) => {
            if (type == typeof (Url) || type == typeof (IEnumerable<Url>)) {
                return true;
            }

            return false;
        };

        public override bool CanReadType(Type type) {
            return _supportedType(type);
        }

        public override bool CanWriteType(Type type) {
            return _supportedType(type);
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content,
            TransportContext transportContext) {
            return Task.Factory.StartNew(() => {
                if (type == typeof (Url) || type == typeof (IEnumerable<Url>)) {
                    BuildObject(value, writeStream,
                        content.Headers.ContentType.MediaType,
                        Convert.ToInt32(content.Headers.GetValues(Constants.API_KEY)));
                }
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
                        foreach (var attr in attrs) {
                            var attribute = attr as jcPVSAttribute;

                            if (!(attribute?.GetMinAPIVersion() >= apiVersion)) {
                                continue;
                            }

                            writer.WritePropertyName(property.Name);
                            writer.WriteValue(property.GetValue(obj));
                        }
                    }

                    writer.WriteEndObject();
                }
            }
        }
    }
}