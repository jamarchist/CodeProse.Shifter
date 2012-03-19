using System;
using CodeProse.Shifter.data;
using CodeProse.Shifter.models;
using CodeProse.Shifter.utility;
using Nancy;

namespace CodeProse.Shifter.modules
{
    public class ShifterModule : NancyModule
    {
        public ShifterModule()
        {   
        }

        public ShifterModule(string path) : base(path)
        {
        }

        protected void BindMasterModel(MasterModel model)
        {
            model.UserName = Context.CurrentUser.UserName;
        }

        protected virtual TResult ExecuteCommand<TResult>(Func<IDatabase, TResult> command)
        {
            using (var database = new Database())
            {
                return command(database);
            }
        }

        protected virtual void ExecuteCommand(Action<IDatabase> command)
        {
            using (var database = new Database())
            {
                command(database);
            }
        }

        protected virtual TEntity Query<TEntity>(Func<IDatabase, TEntity> query)
        {
            using (var database = new Database())
            {
                return query(database);
            }
        }

        protected ShifterViewRenderer ShifterView
        {
            get { return new ShifterViewRenderer(this); }
        }
    }
}