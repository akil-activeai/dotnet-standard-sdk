/**
* Copyright 2018 IBM Corp. All Rights Reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*      http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using Newtonsoft.Json;

namespace IBM.WatsonDeveloperCloud.Discovery.v1.Model
{
    /// <summary>
    /// Object that describes a long query.
    /// </summary>
    public class QueryLarge : BaseModel
    {
        /// <summary>
        /// A cacheable query that excludes documents that don't mention the query content. Filter searches are better
        /// for metadata-type searches and for assessing the concepts in the data set.
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public string Filter { get; set; }
        /// <summary>
        /// A query search returns all documents in your data set with full enrichments and full text, but with the most
        /// relevant documents listed first. Use a query search when you want to find the most relevant search results.
        /// You cannot use **natural_language_query** and **query** at the same time.
        /// </summary>
        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public string Query { get; set; }
        /// <summary>
        /// A natural language query that returns relevant documents by utilizing training data and natural language
        /// understanding. You cannot use **natural_language_query** and **query** at the same time.
        /// </summary>
        [JsonProperty("natural_language_query", NullValueHandling = NullValueHandling.Ignore)]
        public string NaturalLanguageQuery { get; set; }
        /// <summary>
        /// A passages query that returns the most relevant passages from the results.
        /// </summary>
        [JsonProperty("passages", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Passages { get; set; }
        /// <summary>
        /// An aggregation search that returns an exact answer by combining query search with filters. Useful for
        /// applications to build lists, tables, and time series. For a full list of possible aggregations, see the
        /// Query reference.
        /// </summary>
        [JsonProperty("aggregation", NullValueHandling = NullValueHandling.Ignore)]
        public string Aggregation { get; set; }
        /// <summary>
        /// Number of results to return.
        /// </summary>
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; set; }
        /// <summary>
        /// A comma-separated list of the portion of the document hierarchy to return.
        /// </summary>
        [JsonProperty("return", NullValueHandling = NullValueHandling.Ignore)]
        public string ReturnFields { get; set; }
        /// <summary>
        /// The number of query results to skip at the beginning. For example, if the total number of results that are
        /// returned is 10 and the offset is 8, it returns the last two results.
        /// </summary>
        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public long? Offset { get; set; }
        /// <summary>
        /// A comma-separated list of fields in the document to sort on. You can optionally specify a sort direction by
        /// prefixing the field with `-` for descending or `+` for ascending. Ascending is the default sort direction if
        /// no prefix is specified. This parameter cannot be used in the same query as the **bias** parameter.
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public string Sort { get; set; }
        /// <summary>
        /// When true, a highlight field is returned for each result which contains the fields which match the query
        /// with `<em></em>` tags around the matching query terms.
        /// </summary>
        [JsonProperty("highlight", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Highlight { get; set; }
        /// <summary>
        /// A comma-separated list of fields that passages are drawn from. If this parameter not specified, then all
        /// top-level fields are included.
        /// </summary>
        [JsonProperty("passages.fields", NullValueHandling = NullValueHandling.Ignore)]
        public string PassagesFields { get; set; }
        /// <summary>
        /// The maximum number of passages to return. The search returns fewer passages if the requested total is not
        /// found. The default is `10`. The maximum is `100`.
        /// </summary>
        [JsonProperty("passages.count", NullValueHandling = NullValueHandling.Ignore)]
        public long? PassagesCount { get; set; }
        /// <summary>
        /// The approximate number of characters that any one passage will have.
        /// </summary>
        [JsonProperty("passages.characters", NullValueHandling = NullValueHandling.Ignore)]
        public long? PassagesCharacters { get; set; }
        /// <summary>
        /// When `true` and used with a Watson Discovery News collection, duplicate results (based on the contents of
        /// the **title** field) are removed. Duplicate comparison is limited to the current query only; **offset** is
        /// not considered. This parameter is currently Beta functionality.
        /// </summary>
        [JsonProperty("deduplicate", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deduplicate { get; set; }
        /// <summary>
        /// When specified, duplicate results based on the field specified are removed from the returned results.
        /// Duplicate comparison is limited to the current query only, **offset** is not considered. This parameter is
        /// currently Beta functionality.
        /// </summary>
        [JsonProperty("deduplicate.field", NullValueHandling = NullValueHandling.Ignore)]
        public string DeduplicateField { get; set; }
        /// <summary>
        /// A comma-separated list of collection IDs to be queried against. Required when querying multiple collections,
        /// invalid when performing a single collection query.
        /// </summary>
        [JsonProperty("collection_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string CollectionIds { get; set; }
        /// <summary>
        /// When `true`, results are returned based on their similarity to the document IDs specified in the
        /// **similar.document_ids** parameter.
        /// </summary>
        [JsonProperty("similar", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Similar { get; set; }
        /// <summary>
        /// A comma-separated list of document IDs to find similar documents.
        ///
        /// **Tip:** Include the **natural_language_query** parameter to expand the scope of the document similarity
        /// search with the natural language query. Other query parameters, such as **filter** and **query**, are
        /// subsequently applied and reduce the scope.
        /// </summary>
        [JsonProperty("similar.document_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string SimilarDocumentIds { get; set; }
        /// <summary>
        /// A comma-separated list of field names that are used as a basis for comparison to identify similar documents.
        /// If not specified, the entire document is used for comparison.
        /// </summary>
        [JsonProperty("similar.fields", NullValueHandling = NullValueHandling.Ignore)]
        public string SimilarFields { get; set; }
        /// <summary>
        /// Field which the returned results will be biased against. The specified field must be either a **date** or
        /// **number** format. When a **date** type field is specified returned results are biased towards field values
        /// closer to the current date. When a **number** type field is specified, returned results are biased towards
        /// higher field values. This parameter cannot be used in the same query as the **sort** parameter.
        /// </summary>
        [JsonProperty("bias", NullValueHandling = NullValueHandling.Ignore)]
        public string Bias { get; set; }
    }

}
