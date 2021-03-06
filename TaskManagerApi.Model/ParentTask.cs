﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApi.Model
{
    /// <summary>
    /// Parent Task model.
    /// </summary>
    public class ParentTask
    {
        /// <summary>
        /// Unique id of parent task.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of parent task.
        /// </summary>
        public string Name{ get; set; }
    }
}
