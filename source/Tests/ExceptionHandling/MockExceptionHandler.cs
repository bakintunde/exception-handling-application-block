﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Specialized;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Tests
{
    [ConfigurationElementType(typeof(CustomHandlerData))]
    public class MockExceptionHandler : IExceptionHandler
    {
        public static int handleExceptionCount = 0;
        public static string lastMessage;
        public static Guid handlingInstanceID;
        public static NameValueCollection attributes;

        public int instanceHandledExceptionCount = 0;

        public MockExceptionHandler(NameValueCollection attributes)
        {
            MockExceptionHandler.attributes = attributes;
        }
        
        public static void Clear()
        {
            handleExceptionCount = 0;
            lastMessage = String.Empty;
            handlingInstanceID = Guid.Empty;
            attributes = null;
        }

        public static string FormatExceptionMessage(string message, Guid handlingInstanceID)
        {
            return ExceptionUtility.FormatExceptionMessage(message, handlingInstanceID);
        }

        public Exception HandleException(Exception ex, Guid handlingInstanceID)
        {
            instanceHandledExceptionCount++;
            handleExceptionCount++;

            lastMessage = ex.Message;
            MockExceptionHandler.handlingInstanceID = handlingInstanceID;
            return ex;
        }
    }
}

