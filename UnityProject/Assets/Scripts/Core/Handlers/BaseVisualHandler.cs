using Assets.Scripts.Core.Pipeline.Visual;

namespace Assets.Scripts.Core.Handlers
{
    public abstract class BaseVisualHandler<T> : BaseHandler<T>
    {
        protected readonly VisualPipeline VisualPipeline;

        protected BaseVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            VisualPipeline = visualPipeline;
        }

        public override void HandleEvent(T evt)
        {
            
        }
    }
}