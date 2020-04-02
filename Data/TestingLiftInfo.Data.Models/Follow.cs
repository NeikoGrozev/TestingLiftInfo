namespace TestingLiftInfo.Data.Models
{
    using System;

    using TestingLiftInfo.Data.Common.Models;

    public class Follow : BaseDeletableModel<string>
    {
        public Follow()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string LiftId { get; set; }

        public virtual Lift Lift { get; set; }
    }
}
