﻿using AvaSpace.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaSpace.Domain.Interfaces.Repositories
{
    public interface IGalleryRepository : IRepositoryBase<Gallery>
    {
        Gallery GetFeedByUserId(Guid userId);
    }
}