using Microsoft.Extensions.Configuration;

namespace TestBlazor.Constants
{
    public class PageUrls()
    {
        public const string BASE_SERVER_URL = "http://pschool.runasp.net/api";

        public const string MAIN_PAGE_URL = "/";

        // page urls for student side
        public const string MAIN_STUDENT_URL = "/students";
        public const string LIST_STUDENT_URL = MAIN_STUDENT_URL+"/list";
        public const string ADD_STUDENT_URL = MAIN_STUDENT_URL + "/add-students";
        public const string EDIT_STUDENT_URL = MAIN_STUDENT_URL + "/edit/";

        // endpoints for students
        public const string MAIN_STUDENT_ENDPOINT = BASE_SERVER_URL + "/students";
        public const string LIST_STUDENTS_WITH_PARENTS_ENDPOINT = MAIN_STUDENT_ENDPOINT + "/with-parents";
        public const string LIST_PARENTS_NAMES_ENDPOINT = MAIN_STUDENT_ENDPOINT + "/parents-names";

        // page urls for parent side
        public const string MAIN_PARENT_URL =  "/parents";
        public const string LIST_PARENT_URL = MAIN_PARENT_URL + "/list";
        public const string ADD_PARENT_URL = MAIN_PARENT_URL + "/add-parents";
        public const string EDIT_PARENT_URL = MAIN_PARENT_URL + "/edit/";

        // endpoints for parents
        public const string MAIN_PARENT_ENDPOINT = BASE_SERVER_URL + "/parents";
        public const string LIST_PARENTS_WITH_DETAILS_ENDPOINT = MAIN_PARENT_ENDPOINT + "/with-details";
        public const string LIST_PARENTS_SHORT_DETAILS_ENDPOINT = MAIN_PARENT_ENDPOINT + "/with-short-details";
        public const string LIST_PARENT_STUDENTS_ENDPOINT = MAIN_PARENT_ENDPOINT + "/students";
        public const string UPDATE_PARENT_DETAILS_ENDPOINT = MAIN_PARENT_ENDPOINT + "/update-details";


        // page urls for auth side
        public const string MAIN_AUTH_URL = "/auth";

        // users endpoint routes
        public const string MAIN_USER_ENDPOINT = BASE_SERVER_URL + "/users";


    }
}
