// <auto-generated/>
#pragma warning disable
using Marten;
using Marten.Events.Aggregation;
using Marten.Internal.Storage;
using System;
using System.Linq;

namespace Marten.Generated.EventStore
{
    // START: SingleStreamProjectionLiveAggregation650861902
    public class SingleStreamProjectionLiveAggregation650861902 : Marten.Events.Aggregation.SyncLiveAggregatorBase<Subsetsix.Api.Project>
    {
        private readonly Marten.Events.Aggregation.SingleStreamProjection<Subsetsix.Api.Project> _singleStreamProjection;

        public SingleStreamProjectionLiveAggregation650861902(Marten.Events.Aggregation.SingleStreamProjection<Subsetsix.Api.Project> singleStreamProjection)
        {
            _singleStreamProjection = singleStreamProjection;
        }



        public override Subsetsix.Api.Project Build(System.Collections.Generic.IReadOnlyList<Marten.Events.IEvent> events, Marten.IQuerySession session, Subsetsix.Api.Project snapshot)
        {
            if (!events.Any()) return null;
            Subsetsix.Api.Project project = null;
            var usedEventOnCreate = snapshot is null;
            snapshot ??= Create(events[0], session);;
            if (snapshot is null)
            {
                usedEventOnCreate = false;
                snapshot = CreateDefault(events[0]);
            }

            foreach (var @event in events.Skip(usedEventOnCreate ? 1 : 0))
            {
                snapshot = Apply(@event, snapshot, session);
            }

            return snapshot;
        }


        public Subsetsix.Api.Project Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            return null;
        }


        public Subsetsix.Api.Project Apply(Marten.Events.IEvent @event, Subsetsix.Api.Project aggregate, Marten.IQuerySession session)
        {
            switch (@event)
            {
                case Marten.Events.IEvent<Subsetsix.Api.ProjectCreated> event_ProjectCreated1:
                    aggregate.Apply(event_ProjectCreated1);
                    break;
                case Marten.Events.IEvent<Subsetsix.Api.ProjectRenamed> event_ProjectRenamed2:
                    aggregate.Apply(event_ProjectRenamed2.Data);
                    break;
            }

            return aggregate;
        }

    }

    // END: SingleStreamProjectionLiveAggregation650861902
    
    
    // START: SingleStreamProjectionInlineHandler650861902
    public class SingleStreamProjectionInlineHandler650861902 : Marten.Events.Aggregation.AggregationRuntime<Subsetsix.Api.Project, System.Guid>
    {
        private readonly Marten.IDocumentStore _store;
        private readonly Marten.Events.Aggregation.IAggregateProjection _projection;
        private readonly Marten.Events.Aggregation.IEventSlicer<Subsetsix.Api.Project, System.Guid> _slicer;
        private readonly Marten.Internal.Storage.IDocumentStorage<Subsetsix.Api.Project, System.Guid> _storage;
        private readonly Marten.Events.Aggregation.SingleStreamProjection<Subsetsix.Api.Project> _singleStreamProjection;

        public SingleStreamProjectionInlineHandler650861902(Marten.IDocumentStore store, Marten.Events.Aggregation.IAggregateProjection projection, Marten.Events.Aggregation.IEventSlicer<Subsetsix.Api.Project, System.Guid> slicer, Marten.Internal.Storage.IDocumentStorage<Subsetsix.Api.Project, System.Guid> storage, Marten.Events.Aggregation.SingleStreamProjection<Subsetsix.Api.Project> singleStreamProjection) : base(store, projection, slicer, storage)
        {
            _store = store;
            _projection = projection;
            _slicer = slicer;
            _storage = storage;
            _singleStreamProjection = singleStreamProjection;
        }



        public override async System.Threading.Tasks.ValueTask<Subsetsix.Api.Project> ApplyEvent(Marten.IQuerySession session, Marten.Events.Projections.EventSlice<Subsetsix.Api.Project, System.Guid> slice, Marten.Events.IEvent evt, Subsetsix.Api.Project aggregate, System.Threading.CancellationToken cancellationToken)
        {
            switch (evt)
            {
                case Marten.Events.IEvent<Subsetsix.Api.ProjectCreated> event_ProjectCreated3:
                    aggregate ??= CreateDefault(evt);
                    aggregate.Apply(event_ProjectCreated3);
                    return aggregate;
                case Marten.Events.IEvent<Subsetsix.Api.ProjectRenamed> event_ProjectRenamed4:
                    aggregate ??= CreateDefault(evt);
                    aggregate.Apply(event_ProjectRenamed4.Data);
                    return aggregate;
            }

            return aggregate;
        }


        public Subsetsix.Api.Project Create(Marten.Events.IEvent @event, Marten.IQuerySession session)
        {
            return null;
        }

    }

    // END: SingleStreamProjectionInlineHandler650861902
    
    
}
