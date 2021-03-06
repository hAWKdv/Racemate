﻿namespace Racemate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Racemate.Data.Common.Models;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public User()
        {
            this.CreatedOn = DateTime.Now;
            this.Points = 50;
            this.Cars = new HashSet<Car>();
            this.Notifications = new HashSet<Notification>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public int Points { get; set; }

        public bool IsBanned { get; set; }

        public int InvitationCodeId { get; set; }

        public virtual InvitationCode InvitationCode { get; set; }

        public int FirstPlaces { get; set; }

        public int SecondPlaces { get; set; }

        public int ThirdPlaces { get; set; }

        public int TotalRaces { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        // Interfaces

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
