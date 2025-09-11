using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DndNear.API.Models
{
    public class User : IdentityUser
    {
        #region Consts & Static
        #endregion Consts & Static

        #region Fields & Properties

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public bool Administrator { get; set; } = false;

        public DateTime? LastLoginDate { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        [StringLength(32)]
        public required string Username { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        public string? ProfileImageUrl { get; set; }

        #endregion Fields & Properties

        #region Constructors
        #endregion Constructors

        #region Methods

        /// <summary>
        /// Gets the display text: "username" or "username (Name)" if name is available
        /// </summary>
        public string GetDisplayText()
        {
            return string.IsNullOrEmpty(Name)
                ? Username
                : $"{Username} ({Name})";
        }

        #endregion Methods
    }
}
