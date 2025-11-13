using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Runtime.Loader;
using System.Security.Claims;

namespace ResumeProfile.FrameWork.Common
{
    public static class Extensions
    {

        // OnCreated , OnModified , OnDeleted => ShadowProperties


        // Convert miladi to persian date
        public static string ToPersianDate(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date) + "/" + pc.GetMonth(date).ToString("00") + "/" + pc.GetDayOfMonth(date).ToString("00");
        }
        // Convert persian date to miladi
        public static DateTime PersianToDateTime(this string persianDate)
        {
            if (persianDate.Length != 10)
            {
                throw new ArgumentException(nameof(persianDate));
            }
            PersianCalendar persian = new PersianCalendar();
            int year = Convert.ToInt32(persianDate.Substring(0, 4));
            var convertDate = persian.ToDateTime(year, Convert.ToInt32(persianDate.Substring(5, 2)), Convert.ToInt32(persianDate.Substring(8, 2)), 0, 0, 0, 0); ;

            return convertDate;
        }
        //Get User Id
        public static long GetUserId(this HttpContext? httpContext)
        {
            var claimsIdentity = httpContext?.User.Identity as ClaimsIdentity;
            var userIdValue = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            if (long.TryParse(userIdValue, out long userId))
            {
                return userId == 0 ? throw new UnauthorizedAccessException() : userId;
            }

            throw new UnauthorizedAccessException();
        }

        public static Tuple<long?, string?> GetUserInformation(this HttpContext? httpContext)
        {
            long? userId = null;

            var claimsIdentity = httpContext?.User.Identity as ClaimsIdentity;
            var userIdValue = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            userId = string.IsNullOrWhiteSpace(userIdValue) ? null : long.Parse(userIdValue);

            string? userIP = httpContext?.Connection?.RemoteIpAddress.ToString() ?? null;

            return new(userId, userIP);
        }

        //Get User Browser
        public static string GetUserBrowser(this HttpContext context) => context.Request.Headers["User-Agent"].ToString();
        //Get User IP
        public static string GetUserIP(this HttpContext context) => context.Connection.RemoteIpAddress.ToString();
        public async static Task<string> SaveImageAndGenerateName(IFormFile imageFile, string directoryPath)
        {
            if (imageFile == null)
                throw new InvalidDataException("file is Null");

            var fileName = imageFile.FileName;
            fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                              .Replace(":", "")
                              .Replace(".", "") + Path.GetExtension(fileName);

            var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var Url = Path.Combine(folderName, fileName);

            using var stream = new FileStream(Url, FileMode.Create);
            await imageFile.CopyToAsync(stream);

            return fileName;
        }
        public async static Task<string> SaveFileAndGenerateName(IFormFile File, string directoryPath)
        {
            if (File == null)
                throw new InvalidDataException("file is Null");

            var fileName = File.FileName;
            fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                              .Replace(":", "")
                              .Replace(".", "") + Path.GetExtension(fileName);

            var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var Url = Path.Combine(folderName, fileName);

            using var stream = new FileStream(Url, FileMode.Create);
            await File.CopyToAsync(stream);

            return fileName;
        }
        public static string GetImage(string imageName, string ServerPath, string imagePath)
        {
            ServerPath = $"https://{ServerPath}";
            return $"{ServerPath}{imagePath}/{imageName}";
        }
        public static string GetFile(string imageName, string ServerPath, string Path)
        {
            ServerPath = $"https://{ServerPath}";
            return $"{ServerPath}{Path}/{imageName}";
        }
        public static void DeleteFile(string path, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
        public static string GetDayName(this DateTime date)
        {
            string dayOfWeekName = date.DayOfWeek.ToString();
            switch (dayOfWeekName)
            {
                case "Monday":
                    dayOfWeekName = "دوشنبه";
                    break;
                case "Tuesday":
                    dayOfWeekName = "سه‌شنبه";
                    break;
                case "Wednesday":
                    dayOfWeekName = "چهارشنبه";
                    break;
                case "Thursday":
                    dayOfWeekName = "پنج‌شنبه";
                    break;
                case "Friday":
                    dayOfWeekName = "جمعه";
                    break;
                case "Saturday":
                    dayOfWeekName = "شنبه";
                    break;
                case "Sunday":
                    dayOfWeekName = "یک‌شنبه";
                    break;
            }
            return dayOfWeekName;
        }
        public static string ConvertByteArrayToBase64string(this byte[] ImageBytes)
        {
            string imageBase64Data = Convert.ToBase64String(ImageBytes);
            string imgDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            return imgDataURL;
        }

        public static byte[] ConvertIFormFileToByteforImage(IFormFile formFile)
        {
            using MemoryStream memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();

            return imageBytes;
        }
        public static byte[] ConvertIFormFileToByteforFile(IFormFile formFile)
        {
            using MemoryStream memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();

            return imageBytes;
        }
        public static string GetDisplayName(Enum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                .GetField(enumValue.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault() as DisplayAttribute;

            return displayAttribute?.Name ?? enumValue.ToString();
        }

        public static List<string> GetAllClassName(this Type type)
        {
            var _lista = new List<Assembly>();
            foreach (string dllPath in Directory.GetFiles(AppContext.BaseDirectory, "ResumeProfile.*.dll"))
            {
                var shadowCopiedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath);
                _lista.Add(shadowCopiedAssembly);
            }

            return _lista.SelectMany(x => x.GetTypes()).Where(x => type.IsAssignableFrom(x) & !x.IsInterface & !x.IsAbstract).Select(x => x.FullName).ToList();
        }

        public static List<Type> GetAllClassTypes(this Type type)
        {
            var _lista = new List<Assembly>();
            foreach (string dllPath in Directory.GetFiles(AppContext.BaseDirectory, "ResumeProfile.*.dll"))
            {
                var shadowCopiedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath);
                _lista.Add(shadowCopiedAssembly);
            }

            return _lista.SelectMany(x => x.GetTypes()).Where(x => type.IsAssignableFrom(x) & !x.IsInterface & !x.IsAbstract).ToList();

        }
    }
}
