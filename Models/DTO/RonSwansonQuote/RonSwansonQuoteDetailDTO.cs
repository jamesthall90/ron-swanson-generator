﻿using System;

namespace Models.DTO.RonSwansonQuote
{
    public class RonSwansonQuoteDetailDto
    {
        public int Id { get; set; }

        public string Quote { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }
    }
}