using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Text.Json.Serialization;

namespace FastRecipe.Domain.SeedWork
{
    public abstract class Entity : IAggregateRoot
    {
        private int? _requestedHashCode;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string _id { get; protected set; }

        public bool IsTransient() 
            => _id == default;

        public override bool Equals(object obj)
        {
            if (obj == null || (obj is Entity) == false)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            var item = (Entity)obj;
            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item._id == this._id;
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return Equals(right, null);
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
            => !(left == right);

        public override int GetHashCode()
        {
            if (IsTransient() == false)
            {
                if (_requestedHashCode.HasValue == false)
                    _requestedHashCode = _id.GetHashCode(StringComparison.Ordinal) ^ 31;
            }

            return _requestedHashCode.Value;
        }
    }
}
