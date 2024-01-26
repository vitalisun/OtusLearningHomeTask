using System.Linq;
using Assets.Scripts.SaveSystem.Models;
using GameEngine;

public class ResourcesSaveLoader : SaveLoader<ResourcesData, ResourceService>
{
    protected override ResourcesData ConvertToData(ResourceService service)
    {
        return new ResourcesData()
        {
            Resources = service.GetResources().Select(resource => new ResourceData()
            {
                ID = resource.ID,
                Amount = resource.Amount
            })
        };
    }

    protected override void SetupData(ResourcesData data, ResourceService service)
    {

        foreach (var resource in data.Resources)
        {
            var resourceObject = service.GetResource(resource.ID);

            if (resourceObject != null)
            {
                resourceObject.Amount = resource.Amount;
            }
        }
    }
}