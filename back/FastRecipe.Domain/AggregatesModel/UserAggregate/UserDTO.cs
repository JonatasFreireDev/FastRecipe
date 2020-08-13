using System;

namespace FastRecipe.Domain.AggregatesModel.UserAggregate
{
    [Serializable]
    public class UserDTO
    {
        public string Name { get; set; }
        
        public DateTime RegistrationDate;
    }
}
