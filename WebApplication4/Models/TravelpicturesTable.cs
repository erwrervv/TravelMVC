using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class TravelpicturesTable
{
    public int PictureId { get; set; }

    public int? TravelId { get; set; }

    public byte[]? TravelPicture { get; set; }

    public virtual ProductTravel? Travel { get; set; }
}
