﻿namespace NewPlatform.Flexberry.ORM.ODataService.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Controllers;

    /// <summary>
    /// Базовый класс для WebApi-контроллеров.
    /// </summary>
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// Осуществляет инициализацию, которая должна выполниться до начала обработки какого-либо запроса.
        /// </summary>
        /// <param name="controllerContext">Текущий контекст контроллера.</param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            // URL, по которому доступен файловый контроллер.
            // Он необходим для формирования ссылок на скачивание/удаление файлов,
            // но его нельзя определить при инициализации приложения, только в контексте какого-либо запроса.
            // поэтому такая же логика должна быть помещена во все технологические контроллеры.
            if (string.IsNullOrEmpty(FileController.BaseUrl) && !string.IsNullOrEmpty(FileController.RouteName))
            {
                FileController.BaseUrl = Url.Link(FileController.RouteName, new { controller = "File" });
            }
        }
    }
}
