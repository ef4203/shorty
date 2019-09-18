namespace Shorty.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The shorthand entity.
    /// </summary>
    public class Shorthand
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [Key]
        public string URL { get; set; }

        /// <summary>
        /// Gets or sets the destination.
        /// </summary>
        /// <value>
        /// The destination.
        /// </value>
        [Required]
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the date added.
        /// </summary>
        /// <value>
        /// The date added.
        /// </value>
        [Required]
        public DateTime DateAdded { get; set; }
    }
}
