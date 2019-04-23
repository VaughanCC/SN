using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.MSTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vcc.SocialNet.UserService.ServiceTests
{
    /// <summary>
    /// AutoDataAttribute that supports AutoFixture customization for Moq
    /// </summary>
    /// <remarks>
    /// This requires Moq, AutoFixture.AutoMoq, AutoFixture.MSTest NuGet packages.
    /// </remarks>
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
        : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}
