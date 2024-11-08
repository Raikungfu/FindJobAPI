﻿using FindJobsApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models.ViewModel
{
    public class JobServiceViewModel
    {
        public string ServiceName { get; set; }

        public string? Description { get; set; }

        public IFormFile? Image { get; set; }

        public decimal Price { get; set; }

        public double? Duration { get; set; }

        public int? Count { get; set; }

        public JobServiceType jobServiceType { get; set; } = JobServiceType.Other;
    }
}