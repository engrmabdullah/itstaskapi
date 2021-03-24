using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taskapi.Dtos;

namespace taskapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _repo;
        private readonly IMapper _mapper;



        public ItemsController(IItemsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        #region Get All Items 
        [HttpGet("GetItems")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var list = await _repo.GetItems();
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Get All Steps 
        [HttpGet("GetSteps")]
        public async Task<IActionResult> GetSteps()
        {
            try
            {
                var list = await _repo.GetSteps();
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Get Frist Step 
        [HttpGet("GetFristStep")]
        public async Task<IActionResult> GetFristStep()
        {
            try
            {
                var list = await _repo.GetFristStep();
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Get Last Step 
        [HttpGet("GetLastStep")]
        public async Task<IActionResult> GetLastStep()
        {
            try
            {
                var list = await _repo.GetLastStep();
                return Ok(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Add New Item
        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem(ItemForInsertDto forInsert)
        {
            try
            {
               var objInsert = _mapper.Map<Item>(forInsert);
                _repo.Add(objInsert);
                if (await _repo.SaveAll())
                {
                    return NoContent();
                }
                return StatusCode(201);


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion
        #region Add New Update
        [HttpPost("UpdateItem/{ItemId}")]
        public async Task<IActionResult> UpdateItem(int ItemId, ItemForInsertDto forUpdate)
        {
            try
            {
                var row = await _repo.GetItemByItemId(ItemId);
                _mapper.Map(forUpdate, row);
                if (await _repo.SaveAll())
                {
                    return NoContent();
                }
                return StatusCode(201);


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion
        #region Add New Step
        [HttpPost("AddStep")]
        public async Task<IActionResult> AddStep(StepForInsertDto forInsert)
        {
            try
            {
                var objInsert = _mapper.Map<Step>(forInsert);
                _repo.Add(objInsert);
                if (await _repo.SaveAll())
                {
                    return NoContent();
                }
                return StatusCode(201);


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Delete Item
        [HttpGet("DeleteItem/{ItemId}")]
        public async Task<IActionResult> DeleteItem(int ItemId)
        {
          
            try
            {
                
                var row = await _repo.GetItemByItemId(ItemId);
                _repo.Delete(row);
                if (await _repo.SaveAll())
                {
                    return NoContent();
                }
                return StatusCode(201);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Delete Step
        [HttpGet("DeleteStep/{StepId}")]
        public async Task<IActionResult> DeleteStep(int StepId)
        {

            try
            {

                var items = await _repo.GetItemsbyStepId(StepId);
                foreach (var item in items.ToList())
                {
                    _repo.Delete(item);
                    await _repo.SaveAll();
                }

                var row = await _repo.GetStepByStepId(StepId);
                _repo.Delete(row);
                if (await _repo.SaveAll())
                {
                    return NoContent();
                }
                return StatusCode(201);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
