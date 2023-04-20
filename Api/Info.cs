using Microsoft.OpenApi;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;


namespace ProjectApi
{
    public class Info: IOpenApiSerializable, IOpenApiExtensible
    {
        /// <summary>
        /// REQUIRED. The title of the application.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A short description of the application.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// REQUIRED. The version of the OpenAPI document.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// A URL to the Terms of Service for the API. MUST be in the format of a URL.
        /// </summary>
        public Uri TermsOfService { get; set; }

        /// <summary>
        /// The contact information for the exposed API.
        /// </summary>
        public OpenApiContact Contact { get; set; }

        /// <summary>
        /// The license information for the exposed API.
        /// </summary>
        public OpenApiLicense License { get; set; }

        /// <summary>
        /// This object MAY be extended with Specification Extensions.
        /// </summary>
        public IDictionary<string, IOpenApiExtension> Extensions { get; set; } = new Dictionary<string, IOpenApiExtension>();

        /// <summary>
        /// Serialize <see cref="OpenApiInfo"/> to Open Api v3.0
        /// </summary>
        public void SerializeAsV3(IOpenApiWriter writer)
        {
            if (writer == null)
            {
               // throw Error.ArgumentNull(nameof(writer));
            }

            writer.WriteStartObject();

            // title
            writer.WriteProperty(OpenApiConstants.Title, Title);

            // description
            writer.WriteProperty(OpenApiConstants.Description, Description);

            // termsOfService
            writer.WriteProperty(OpenApiConstants.TermsOfService, TermsOfService?.OriginalString);

            // contact object
            writer.WriteOptionalObject(OpenApiConstants.Contact, Contact, (w, c) => c.SerializeAsV3(w));

            // license object
            writer.WriteOptionalObject(OpenApiConstants.License, License, (w, l) => l.SerializeAsV3(w));

            // version
            writer.WriteProperty(OpenApiConstants.Version, Version);

            // specification extensions
            writer.WriteExtensions(Extensions, OpenApiSpecVersion.OpenApi3_0);

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize <see cref="OpenApiInfo"/> to Open Api v2.0
        /// </summary>
        public void SerializeAsV2(IOpenApiWriter writer)
        {
            if (writer == null)
            {
              //  throw Error.ArgumentNull(nameof(writer));
            }

            writer.WriteStartObject();

            // title
            writer.WriteProperty(OpenApiConstants.Title, Title);

            // description
            writer.WriteProperty(OpenApiConstants.Description, Description);

            // termsOfService
            writer.WriteProperty(OpenApiConstants.TermsOfService, TermsOfService?.OriginalString);

            // contact object
            writer.WriteOptionalObject(OpenApiConstants.Contact, Contact, (w, c) => c.SerializeAsV2(w));

            // license object
            writer.WriteOptionalObject(OpenApiConstants.License, License, (w, l) => l.SerializeAsV2(w));

            // version
            writer.WriteProperty(OpenApiConstants.Version, Version);

            // specification extensions
            writer.WriteExtensions(Extensions, OpenApiSpecVersion.OpenApi2_0);

            writer.WriteEndObject();
        }
    }
}
