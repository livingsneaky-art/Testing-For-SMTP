﻿using Basecode.Data.Interfaces;
using Basecode.Data.Models;
using Basecode.Data.ViewModels;
using Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basecode.Services.Services
{
    public class JobOpeningService : IJobOpeningService
    {
        private readonly IJobOpeningRepository _repository;

        public JobOpeningService(IJobOpeningRepository repository)
        {
            _repository = repository;
        }

        public List<JobOpeningViewModel> GetJobs()
        {
            var data = _repository.GetAll().Select(m => new JobOpeningViewModel
            {
                Id = m.Id,
                Title = m.Title,
                EmploymentType = m.EmploymentType,
                WorkSetup = m.WorkSetup,
                Location = m.Location,
                Category = m.Category
            }).ToList();

            return data;
        }

        public void Create(JobOpening jobOpening, string createdBy)
        {
            jobOpening.CreatedBy = createdBy;
            jobOpening.CreatedTime = DateTime.Now;
            jobOpening.UpdatedBy = createdBy;
            jobOpening.UpdatedTime = DateTime.Now;

            _repository.AddJobOpening(jobOpening);
        }

        public JobOpeningViewModel GetById(int id)
        {
            var data = _repository.GetAll().Where(m => m.Id == id).Select(m => new JobOpeningViewModel
            {
                Id = m.Id,
                Title = m.Title,
                EmploymentType = m.EmploymentType,
                WorkSetup = m.WorkSetup,
                Location = m.Location,
                Category = m.Category
            }).FirstOrDefault();

            return data;
        }


        public void Update(JobOpening jobOpening, string updatedBy)
        {
            jobOpening.UpdatedBy = updatedBy;
            jobOpening.UpdatedTime = DateTime.Now;

            _repository.UpdateJobOpening(jobOpening);
        }

        public void Delete(JobOpeningViewModel jobOpening)
        {
            var job = new JobOpening
            {
                Id = jobOpening.Id,
                Title = jobOpening.Title,
                EmploymentType = jobOpening.EmploymentType,
                WorkSetup = jobOpening.WorkSetup,
                Location = jobOpening.Location,
                Category = jobOpening.Category
            };

            _repository.DeleteJobOpening(job);
        }

    }
}
