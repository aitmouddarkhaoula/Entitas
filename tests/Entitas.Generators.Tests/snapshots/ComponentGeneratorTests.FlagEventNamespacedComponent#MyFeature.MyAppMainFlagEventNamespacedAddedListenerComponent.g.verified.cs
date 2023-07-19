﻿//HintName: MyFeature.MyAppMainFlagEventNamespacedAddedListenerComponent.g.cs
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by
//     Entitas.Generators.ComponentGenerator.Events
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using global::MyApp.Main;

namespace MyFeature
{
public interface IMyAppMainFlagEventNamespacedAddedListener
{
    void OnFlagEventNamespacedAdded(Entity entity);
}

public sealed class MyAppMainFlagEventNamespacedAddedListenerComponent : global::Entitas.IComponent
{
    public global::System.Collections.Generic.List<IMyAppMainFlagEventNamespacedAddedListener> Value;
}

public static class MyAppMainFlagEventNamespacedAddedListenerEventEntityExtension
{
    public static Entity AddFlagEventNamespacedAddedListener(this Entity entity, IMyAppMainFlagEventNamespacedAddedListener value)
    {
        var listeners = entity.HasFlagEventNamespacedAddedListener()
            ? entity.GetFlagEventNamespacedAddedListener().Value
            : new global::System.Collections.Generic.List<IMyAppMainFlagEventNamespacedAddedListener>();
        listeners.Add(value);
        return entity.ReplaceFlagEventNamespacedAddedListener(listeners);
    }

    public static void RemoveFlagEventNamespacedAddedListener(this Entity entity, IMyAppMainFlagEventNamespacedAddedListener value, bool removeListenerWhenEmpty = true)
    {
        var listeners = entity.GetFlagEventNamespacedAddedListener().Value;
        listeners.Remove(value);
        if (removeListenerWhenEmpty && listeners.Count == 0)
        {
            entity.RemoveFlagEventNamespacedAddedListener();
            if (entity.IsEmpty())
                entity.Destroy();
        }
        else
        {
            entity.ReplaceFlagEventNamespacedAddedListener(listeners);
        }
    }
}

public sealed class MyAppMainFlagEventNamespacedAddedEventSystem : global::Entitas.ReactiveSystem<Entity>
{
    readonly global::System.Collections.Generic.List<IMyAppMainFlagEventNamespacedAddedListener> _listenerBuffer;

    public MyAppMainFlagEventNamespacedAddedEventSystem(MyApp.MainContext context) : base(context)
    {
        _listenerBuffer = new global::System.Collections.Generic.List<IMyAppMainFlagEventNamespacedAddedListener>();
    }

    protected override global::Entitas.ICollector<Entity> GetTrigger(global::Entitas.IContext<Entity> context)
    {
        return global::Entitas.CollectorContextExtension.CreateCollector(
            context, global::Entitas.TriggerOnEventMatcherExtension.Added(MyAppMainFlagEventNamespacedMatcher.FlagEventNamespaced)
        );
    }

    protected override bool Filter(Entity entity)
    {
        return entity.HasFlagEventNamespaced() && entity.HasFlagEventNamespacedAddedListener();
    }

    protected override void Execute(global::System.Collections.Generic.List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(entity.GetFlagEventNamespacedAddedListener().Value);
            foreach (var listener in _listenerBuffer)
            {
                listener.OnFlagEventNamespacedAdded(entity);
            }
        }
    }
}
}