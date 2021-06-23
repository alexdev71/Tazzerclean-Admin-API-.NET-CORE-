using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts.Entities
{
    public class Gallery
    {
        public byte[] Image { get; set; }

        public string Description { get; set; }

        public GalleryType Type { get; set; }

        public Guid ExternalId { get; set; }
    }
}
