namespace ASPNetCoreWebAPI_Reactjs.Helpers
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string title)
        {
            // Convert to lowercase
            string slug = title.ToLowerInvariant();

            // Replace spaces with hyphens
            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"\s+", "-");

            // Remove invalid characters
            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"[^a-z0-9\-]", "");

            // Trim hyphens from ends
            slug = slug.Trim('-');

            // Ensure the slug is not empty
            if (string.IsNullOrEmpty(slug))
            {
                slug = "post";
            }

            return slug;
        }
    }
}
