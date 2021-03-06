﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_.Domain.utils {
    public class Predicates {
        public static bool IsNull<T>(T value) where T : class {
            return value == null;
        }

        public static bool IsNotNull<T>(T value) where T : class {
            return value != null;
        }

        public static bool IsNull<T>(T? nullableValue) where T : struct {
            return !nullableValue.HasValue;
        }

        public static bool IsNotNull<T>(T? nullableValue) where T : struct {
            return nullableValue.HasValue;
        }

        public static bool HasValue<T>(T? nullableValue) where T : struct {
            return nullableValue.HasValue;
        }

        public static bool HasNoValue<T>(T? nullableValue) where T : struct {
            return !nullableValue.HasValue;
        }
    }
}