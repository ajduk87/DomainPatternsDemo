namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Product
{
    public class VideoLink : ValueObject
    {
        public string Content { get; set; }

        public VideoLink(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator VideoLink(string videoLink)
        {
            return new VideoLink(videoLink);
        }

        public static implicit operator string(VideoLink videoLink)
        {
            return videoLink.Content;
        }

        public override string ToString()
        {
            return this.Content;
        }
    }
}