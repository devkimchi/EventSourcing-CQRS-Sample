namespace EventSourcingCqrsSample.Models.ViewModels.Salutations
{
    /// <summary>
    /// This represents the entity for salutation.
    /// </summary>
    public class Salutation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Salutation" /> class.
        /// </summary>
        public Salutation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Salutation" /> class.
        /// </summary>
        /// <param name="text">Salutation text.</param>
        /// <param name="value">Salutation value.</param>
        public Salutation(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the salutation text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the salutation value.
        /// </summary>
        public string Value { get; set; }
    }
}