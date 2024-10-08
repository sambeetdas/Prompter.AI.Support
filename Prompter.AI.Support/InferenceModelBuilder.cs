﻿using Prompter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prompter.AI.Support
{
    public static class InferenceModelBuilder
    {
        public static InferenceConfigModel Build()
        {
            var config = new InferenceConfigModel
            {
                ModelProvider = ModelProviderEnum.HuggingFace,
                URL = "https://api-inference.huggingface.co/models/mistralai/Mistral-7B-Instruct-v0.3",
                AuthKey = "",
                MaxNewToken = 100,
                TopP = 0.1,
                Temperature = 0.1,
                Prefix = new List<String>
                {
                    $"1.Question asked is above within ''.",
                    $"2.'DataSource' hold all the data for the above 'Question'.",
                    $"3.Asked question should be filtered from the 'DataSource' with the help 'Keys'.",
                    $"4.Phrase the answer in English.",
                    $"5.Encapsulate the answer within <<>>.",
                    $"6.Below are the details to evaluate the answer for the Question asked."

                },
                ToolModel = new ToolModel
                {
                    APISource = new List<APISourceDetails>
                    {
                        new APISourceDetails
                        {
                            Id = "get_all_phones",
                            Description = "This api is used to get the list of phones",
                            Url = "https://api.restful-api.dev/objects",
                            Method = "GET",
                            Headers = new Dictionary<string, string>
                            {
                                { "Accept", "application/json" }
                            },
                            Request = string.Empty,
                            ResponseKeys = new List<ResponseKeys>()
                            {
                                new ResponseKeys
                                {
                                    KeyName = "startdate",
                                    KeyType = ResponseKeyTypeEnum.QueryParameter,
                                    Description = "determine the date in yyyy-mm-dd format."
                                },
                                new ResponseKeys
                                {
                                    KeyName = "name",
                                    KeyType = ResponseKeyTypeEnum.Static,
                                    Description = "name of the phone"
                                },
                                new ResponseKeys
                                {
                                    KeyName = "color",
                                    KeyType = ResponseKeyTypeEnum.Static,
                                    Description = "color of the phone"
                                },
                                 new ResponseKeys
                                {
                                    KeyName = "capacity",
                                    KeyType = ResponseKeyTypeEnum.Static,
                                    Description = "capacity of the phone"
                                },
                                  new ResponseKeys
                                {
                                    KeyName = "year",
                                    KeyType = ResponseKeyTypeEnum.Static,
                                    Description = "year on which the phone launched"
                                }
                            }

                        },
                        new APISourceDetails
                        {
                            Id = "get_breeds_of_dogs",
                            Description = "This api is used to get the list of breeds of dogs",
                            Url = "https://dogapi.dog/api/v2/breeds",
                            Method = "GET",
                            Headers = new Dictionary<string, string>
                            {
                                { "Accept", "application/json" }
                            },
                            Request = string.Empty,
                            ResponseKeys = new List<ResponseKeys>()
                            {
                                new ResponseKeys
                                {
                                    KeyName = "name",
                                    KeyType = ResponseKeyTypeEnum.Static,
                                    Description = "name of dog's breed"
                                },
                                new ResponseKeys
                                {
                                    KeyName = "description",
                                    KeyType = ResponseKeyTypeEnum.Static,
                                    Description = "description of dog's breed"
                                }
                            }
                        }
                    }
                }
            };

            return config;
        }
    }
}
