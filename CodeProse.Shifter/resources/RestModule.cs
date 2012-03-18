using System;
using CodeProse.Shifter.data.queries;
using CodeProse.Shifter.modules;
using CodeProse.Shifter.utility;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Extensions;

namespace CodeProse.Shifter.resources
{
    public abstract class RestModule<TEntity> : SecureModule where TEntity : class
    {
        protected RestModule(string path) : base(path)
        {
            Post["/"] = x =>
            {
                var newResource = this.Bind<TEntity>();
                var id = ExecuteCommand(db => db.Insert(newResource));

                var response = Response.AsJson(newResource);
                response.StatusCode = HttpStatusCode.Created;

                var resourcePath = (string)String.Format("~/{0}/{1}", path, id);
                response.Headers.Add("Location", Context.ToFullPath(resourcePath));

                return response; 
            };

            Get["/"] = x =>
            {
                var resources = Query(db => db.GetAll<TEntity>());
                return Response.AsJson(resources);                       
            };

            Get[RoutingExpressions.Guid] = x =>
            {
                var identifier = Guid.Parse((string)x.guid);
                var resource = Query(db => db.Get<TEntity>(identifier));

                return Response.AsJson(resource);
            };

            Delete[RoutingExpressions.Guid] = x =>
            {
                var identifier = Guid.Parse((string)x.guid);
                ExecuteCommand(db =>
                {

                    var resource = db.Get<TEntity>(identifier);

                    if (resource != null)
                    {
                        db.Delete(resource);
                    }
                });

                return HttpStatusCode.ResetContent;
            };
        }
    }
}