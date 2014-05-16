﻿// 
//  Copyright (c) Microsoft Corporation. All rights reserved. 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  

namespace Microsoft.OneGet.Core.Extensions {
    using System;
    using System.Collections.Generic;
    using Collections;
    using DuckTyping;

    public class LazyReadOnlyDelgateDictionary<K, V> : Lazy<IDictionary<K, V>> {
        public LazyReadOnlyDelgateDictionary(Func<ICollection<K>> keyCollectionFn, Func<K, V> valueLookupFn)
            : base(() => keyCollectionFn.IsSupported() && valueLookupFn.IsSupported() ? (IDictionary<K, V>)new ReadOnlyDelegateDictionary<K, V>(keyCollectionFn().ByRef, valueLookupFn) : new Dictionary<K, V>()) {
        }
    }
}