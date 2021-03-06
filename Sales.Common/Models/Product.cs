﻿namespace Sales.Common.Models
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Decimal Price { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        [Display(Name = "Publish On")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime PublishOn { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImagePath))
                {
                    return "no_image";
                }

                return $"https://salesapiservices.azurewebsites.net/{this.ImagePath.Substring(1)}";
            }
        }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
