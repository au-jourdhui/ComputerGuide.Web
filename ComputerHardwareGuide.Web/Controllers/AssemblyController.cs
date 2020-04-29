using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ComputerHardwareGuide.DAL;
using System.Threading.Tasks;
using ComputerHardwareGuide.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ComputerHardwareGuide.DAL.Models.Components;
using System;
using ComputerHardwareGuide.Web.ViewModels;

namespace ComputerHardwareGuide.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssemblyController : BaseComputerHardwareGuideController
    {
        public AssemblyController(IAppContext appContext) : base(appContext) { }

        [HttpGet]
        public async Task<IEnumerable<Assembly>> Get()
        {
            var query = AppContext.Assemblies.AsQueryable();

            return await query.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<GetAssemblyVM> Get(int id)
        {
            var query = AppContext.Assemblies.Include(x => x.AssemblyComponents).ThenInclude(x => x.ComponentType).AsQueryable();
            var assembly = await query.FirstOrDefaultAsync(x => x.Id == id);

            var total = 0.0;
            if (assembly.AssemblyComponents?.Count > 0)
            {
                foreach (var item in assembly.AssemblyComponents)
                {
                    var component = GetQuery(item.ComponentType.ComponentTypeEnumeration).FirstOrDefault(x=>x.Id == item.ComponentId);
                    LoadPictures(component, 1);
                    item.BaseComponent = component;
                    total += component.Price * item.Quantity;
                }
            }

            return new GetAssemblyVM
            {
                Assembly = assembly,
                Total = total,
            };
        }

        [HttpPost]
        public async Task<IActionResult> Post(Assembly assembly)
        {
            try
            {
                AppContext.Assemblies.Add(assembly);
                await AppContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return CreatedAtAction(nameof(Post), assembly);
        }

        [HttpPost("component")]
        public async Task<IActionResult> Post(AddAssemblyComponentVM model)
        {
            var assemblyComponent = (AssemblyComponent)null;
            try
            {
                var assembly = await AppContext.Assemblies.FirstOrDefaultAsync(x => x.Id == model.AssemblyId);
                var component = await GetQuery(model.Type).FirstOrDefaultAsync(x => x.Id == model.ComponentId);
                var componentType = await AppContext.ComponentTypes.FirstOrDefaultAsync(x => x.Id == (int)model.Type);

                assemblyComponent = new AssemblyComponent
                {
                    Assembly = assembly,
                    ComponentId = component.Id,
                    ComponentType = componentType,
                    Quantity = model.Quantity,
                };
                AppContext.AssemblyComponents.Add(assemblyComponent);
                await AppContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return CreatedAtAction(nameof(Post), assemblyComponent);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateAssemblyVM model)
        {
            var assembly = (Assembly)null;
            try
            {
                assembly = await AppContext.Assemblies.FirstOrDefaultAsync(x => x.Id == model.AssemblyId);
                if (!string.IsNullOrWhiteSpace(model.Name))
                {
                    assembly.Name = model.Name;
                }
                if (model.ToPrice.HasValue)
                {
                    assembly.ToPrice = model.ToPrice.Value;
                }

                AppContext.Assemblies.Update(assembly);
                await AppContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(assembly);
        }

        [HttpPut("component")]
        public async Task<IActionResult> Put(UpdateAssemblyComponentVM model)
        {
            var assemblyComponent = (AssemblyComponent)null;
            try
            {
                if (model.Quantity < 1)
                {
                    throw new ArgumentException("Quantity of assembly component should be at least 1.", "quantity");
                }

                assemblyComponent = await AppContext.AssemblyComponents.FirstOrDefaultAsync(x => x.Id == model.AssemblyComponentId);
                assemblyComponent.Quantity = model.Quantity;
                AppContext.AssemblyComponents.Update(assemblyComponent);
                await AppContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok(assemblyComponent);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int assemblyId)
        {
            try
            {
                var assembly = await AppContext.Assemblies.FindAsync(assemblyId);

                if (assembly == null)
                {
                    return NotFound();
                }

                var assemblyComponents = await AppContext.AssemblyComponents.AsQueryable().Where(x => x.Assembly.Id == assemblyId).ToListAsync();
                AppContext.AssemblyComponents.RemoveRange(assemblyComponents);
                AppContext.Assemblies.Remove(assembly);
                await AppContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        [HttpDelete("component")]
        public async Task<IActionResult> Delete(int assemblyId, int componentId)
        {
            try
            {
                var assemblyComponent = await AppContext.AssemblyComponents.FirstOrDefaultAsync(x => x.Assembly.Id == assemblyId && x.ComponentId == componentId);

                if (assemblyComponent == null)
                {
                    return NotFound();
                }

                AppContext.AssemblyComponents.Remove(assemblyComponent);
                await AppContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }
    }
}