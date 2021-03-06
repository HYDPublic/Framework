namespace Boxed.AspNetCore.TagHelpers.Test.Twitter.Cards
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Boxed.AspNetCore.TagHelpers.Twitter;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using TestData;
    using Xunit;

    /// <summary>
    /// TwitterCard App Tests
    /// </summary>
    public class TwitterCard_App_Test
    {
        /// <summary>
        /// Renders the meta tags with no value for google play. (exception thrown)
        /// </summary>
        [Fact(DisplayName = "RenderMetaTags_NoValueForGooglePlay_ExceptionThrown")]
        public void RenderMetaTags_NoValueForGooglePlay_ExceptionThrown()
        {
            var expected = typeof(System.ArgumentNullException);
            Exception thrownException = null;

            TwitterCardApp myTagHelper = new TwitterCardApp()
            {
                SiteUsername = TwitterCardAnswerKey.SiteUsernameValue,
                IPhone = "307234931",
                IPad = "307234931",
                GooglePlay = string.Empty
            };

            try
            {
                var context = new TagHelperContext(
                    new TagHelperAttributeList(),
                    new Dictionary<object, object>(),
                    Guid.NewGuid().ToString("N"));

                var output = new TagHelperOutput(
                    "meta",
                    new TagHelperAttributeList(),
                    (cache, encoder) =>
                    {
                        var tagHelperContent = new DefaultTagHelperContent();
                        tagHelperContent.SetContent(string.Empty);
                        return Task.FromResult<TagHelperContent>(tagHelperContent);
                    });

                myTagHelper.Process(context, output);
            }
            catch (Exception e)
            {
                thrownException = e;
            }

            Assert.Equal(expected, thrownException.GetType());
            Assert.Equal("GooglePlay", ((System.ArgumentException)thrownException).ParamName.ToString());
        }

        /// <summary>
        /// Renders the meta tags with no value for iPad. (exception thrown)
        /// </summary>
        [Fact(DisplayName = "RenderMetaTags_NoValueForIPad_ExceptionThrown")]
        public void RenderMetaTags_NoValueForIPad_ExceptionThrown()
        {
            var expected = typeof(System.ArgumentNullException);
            Exception thrownException = null;

            TwitterCardApp myTagHelper = new TwitterCardApp()
            {
                SiteUsername = TwitterCardAnswerKey.SiteUsernameValue,
                IPhone = "307234931",
                IPad = string.Empty,
                GooglePlay = "com.android.app"
            };

            try
            {
                var context = new TagHelperContext(
                    new TagHelperAttributeList(),
                    new Dictionary<object, object>(),
                    Guid.NewGuid().ToString("N"));

                var output = new TagHelperOutput(
                    "meta",
                    new TagHelperAttributeList(),
                    (cache, encoder) =>
                    {
                        var tagHelperContent = new DefaultTagHelperContent();
                        tagHelperContent.SetContent(string.Empty);
                        return Task.FromResult<TagHelperContent>(tagHelperContent);
                    });

                myTagHelper.Process(context, output);
            }
            catch (Exception e)
            {
                thrownException = e;
            }

            Assert.Equal(expected, thrownException.GetType());
            Assert.Equal("IPad", ((System.ArgumentException)thrownException).ParamName.ToString());
        }

        /// <summary>
        /// Renders the meta tags with no value for twitter site username. (exception thrown)
        /// </summary>
        [Fact(DisplayName = "RenderMetaTags_NoValueForSiteUsername_ExceptionThrown")]
        public void RenderMetaTags_NoValueForSiteUsername_ExceptionThrown()
        {
            var expected = typeof(System.ArgumentNullException);
            Exception thrownException = null;

            TwitterCardApp myTagHelper = new TwitterCardApp()
            {
                SiteUsername = string.Empty,
                IPhone = "307234931",
                IPad = "307234931",
                GooglePlay = "com.android.app"
            };

            try
            {
                var context = new TagHelperContext(
                     new TagHelperAttributeList(),
                     new Dictionary<object, object>(),
                     Guid.NewGuid().ToString("N"));

                var output = new TagHelperOutput(
                    "meta",
                    new TagHelperAttributeList(),
                    (cache, encoder) =>
                    {
                        var tagHelperContent = new DefaultTagHelperContent();
                        tagHelperContent.SetContent(string.Empty);
                        return Task.FromResult<TagHelperContent>(tagHelperContent);
                    });

                myTagHelper.Process(context, output);
            }
            catch (Exception e)
            {
                thrownException = e;
            }

            Assert.Equal(expected, thrownException.GetType());
            Assert.Equal("SiteUsername", ((System.ArgumentException)thrownException).ParamName.ToString());
        }

        /// <summary>
        /// Renders the correct twitter card type tag.
        /// </summary>
        [Fact(DisplayName = "RenderMetaTags_RenderedCorrectTwitterCardTypeTag_Match")]
        public void RenderMetaTags_RenderedCorrectTwitterCardTypeTag_Match()
        {
            TwitterCardApp myTagHelper = new TwitterCardApp()
            {
                SiteUsername = TwitterCardAnswerKey.SiteUsernameValue,
                IPhone = "307234931",
                IPad = "307234931",
                GooglePlay = "com.android.app"
            };

            var context = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                Guid.NewGuid().ToString("N"));

            var output = new TagHelperOutput(
                "meta",
                new TagHelperAttributeList(),
                (cache, encoder) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent();
                    tagHelperContent.SetContent(string.Empty);
                    return Task.FromResult<TagHelperContent>(tagHelperContent);
                });

            myTagHelper.Process(context, output);
            Assert.Contains("name=\"twitter:card\" content=\"app\"", output.Content.GetContent());
        }

        /// <summary>
        /// Renders the meta tags for the card application validation fails missing iPhone.
        /// (exception thrown)
        /// </summary>
        [Fact(DisplayName = "RenderMetaTags_NoValueForIPhone_ExceptionThrown")]
        public void TwitterCard_App_Validation_Fails_Missing_IPhone()
        {
            var expected = typeof(System.ArgumentNullException);
            Exception thrownException = null;

            TwitterCardApp myTagHelper = new TwitterCardApp()
            {
                SiteUsername = TwitterCardAnswerKey.SiteUsernameValue,
                IPhone = string.Empty,
                IPad = "307234931",
                GooglePlay = "com.android.app"
            };

            try
            {
                var context = new TagHelperContext(
                    new TagHelperAttributeList(),
                    new Dictionary<object, object>(),
                    Guid.NewGuid().ToString("N"));

                var output = new TagHelperOutput(
                    "meta",
                    new TagHelperAttributeList(),
                    (cache, encoder) =>
                    {
                        var tagHelperContent = new DefaultTagHelperContent();
                        tagHelperContent.SetContent(string.Empty);
                        return Task.FromResult<TagHelperContent>(tagHelperContent);
                    });

                myTagHelper.Process(context, output);
            }
            catch (Exception e)
            {
                thrownException = e;
            }

            Assert.Equal(expected, thrownException.GetType());
            Assert.Equal("IPhone", ((System.ArgumentException)thrownException).ParamName.ToString());
        }
    }
}