﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlazorAdmin.Services.CatalogItemService
{
    public class Delete
    {
        private readonly AuthService _authService;

        public Delete(AuthService authService)
        {
            _authService = authService;
        }

        public async Task<string> HandleAsync(int catalogItemId)
        {
            var catalogItemResult = string.Empty;

            var result = await _authService.GetHttpClient().DeleteAsync($"{Constants.API_URL}catalog-items/{catalogItemId}");
            if (result.StatusCode != HttpStatusCode.OK)
            {
                return catalogItemResult;
            }

            catalogItemResult = JsonConvert.DeserializeObject<DeleteCatalogItemResult>(await result.Content.ReadAsStringAsync()).Status;

            return catalogItemResult;
        }
    }
}
