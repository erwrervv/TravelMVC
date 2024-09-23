﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class article_overview
{
    public int article_id { get; set; }

    public int? memberunique_id { get; set; }

    public string article_name { get; set; }

    public string article_content { get; set; }

    public DateTime? create_time { get; set; }

    public DateTime? update_time { get; set; }

    public byte[] article_cover_image { get; set; }

    public string ArticleCoverImageString { get; set; }

    public string tag { get; set; }

    public virtual ICollection<article_picture> article_picture { get; set; } = new List<article_picture>();

    public virtual ICollection<article_repository> article_repository { get; set; } = new List<article_repository>();

    public virtual ICollection<comment> comment { get; set; } = new List<comment>();

    public virtual ICollection<members_like> members_like { get; set; } = new List<members_like>();

    public virtual basic_member_information memberunique { get; set; }
}