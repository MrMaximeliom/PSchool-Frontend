using Microsoft.Extensions.Configuration;

namespace TestBlazor.Constants
{
    public class PageUrls()
    {
        public const string BASE_SERVER_URL = "https://localhost:7168/api";

        public const string MainPageUrl = "/";

        // page urls for student side
        public const string MainStudentUrl = "/students";
        public const string ListStudentUrl = MainStudentUrl+"/list";
        public const string AddStudentUrl = MainStudentUrl + "/add-students";
        public const string EditStudentUrl = MainStudentUrl + "/edit/";

        // page urls for parent side
        public const string MainParentUrl = "/parents";
        public const string ListParentUrl = MainParentUrl + "/list";
        public const string AddParentUrl = MainParentUrl + "/add-parents";
        public const string EditParentUrl = MainParentUrl + "/edit/";

        // page urls for auth side
        public const string MainAuthUrl = "/auth";

        // users endpoint routes
        public const string MAIN_USER_ROUTE = "/users";


    }
}
