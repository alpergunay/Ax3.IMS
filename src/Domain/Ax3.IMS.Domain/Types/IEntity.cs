﻿using System;

namespace Ax3.IMS.Domain.Types
{
    /// <summary>
    /// mongo entity interface
    /// </summary>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// create date
        /// </summary>
        DateTime CreatedOn { get; }

        /// <summary>
        /// id in string format
        /// </summary>
        TKey Id { get; set; }

        /// <summary>
        /// modify date
        /// </summary>
        DateTime ModifiedOn { get; }
    }
}