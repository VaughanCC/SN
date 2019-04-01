using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Vcc.SocialNet.UserService.Common
{
    public enum PositionEnum : short
    {
        // 담임목사
        [Description("Senior Pastor")]
        SeniorPastor = 0,
        // 부목사
        [Description("Assistant Pastor")]
        AssistantPastor = 1,
        // 전도사
        [Description("Junior Pastor")]
        JuniorPastor = 2,
        // 시무장로
        [Description("Active Elder")]
        ActiveElder = 3,
        // 장로
        [Description("Elder")]
        Elder = 4,
        // 권사
        [Description("Senior Deaconess")]
        SeniorDeaconess = 5,
        // 안수집사
        [Description("Ordained Deacon")]
        OrdainedDeacon = 6,
        // 서리집사
        [Description("Deputy Deacon")]
        DeputyDeacon = 7,
        // 평신도
        [Description("Layman")]
        Layman = 8
    }
}
