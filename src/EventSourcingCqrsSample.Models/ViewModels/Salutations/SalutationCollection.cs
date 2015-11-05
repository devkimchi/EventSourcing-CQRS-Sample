using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace EventSourcingCqrsSample.Models.ViewModels.Salutations
{
    /// <summary>
    /// This represents the collection entity for salutations.
    /// </summary>
    public class SalutationCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalutationCollection" /> class.
        /// </summary>
        public SalutationCollection()
        {
            this.Salutations = new List<Salutation>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalutationCollection" /> class.
        /// </summary>
        /// <param name="salutations">The list of <see cref="Salutation" /> objects.</param>
        public SalutationCollection(IEnumerable<Salutation> salutations)
        {
            this.Salutations = salutations.ToList();
        }

        /// <summary>
        /// Gets or sets the list of salutations.
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public List<Salutation> Salutations { get; set; }
    }
}