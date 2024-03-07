using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMPUS_NAVIGATION.Classes
{
    internal class FirestoreHelper
    {
        static string fireconfig = @"
        {
          ""type"": ""service_account"",
          ""project_id"": ""authentication-v1-4e63f"",
          ""private_key_id"": ""35aa6f44d73a223b784c2f2a0223b0dba2e750d1"",
          ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQDbPAhG+546UDJP\nJBpvOSXJ3bqYgt8CrQsUBkU6j/WLQK064+yJUvVQGdm+o7Oc2XYGna6dZzEFLTk5\nWUEi4eEbOpNQaAxpx+c1Rcr9WC8B+aJa5I7opIqC9t9VN8XYxuiaYtII3z5CrSsc\nEtSQl17ixqlZW6IRaLz+glfH+LsUym1aVC1mzsngKn5OM0LjHsarbL/GPY3/TfQg\n7ZROuqLDqsNHBFQ6I9XjAcPnGesBu63paVzLsKJRpTFzNT3Syn7YJ0yTbXLHT591\nFJqdlBja8+PO/LU2+5Sjx3bBlCHtAApsyBoLo1PF0cEd+l2x7IsWoi9tzv1xyZ+k\nLtn5HQpZAgMBAAECggEADtInoxjWkQ2j4QrJSLSd0+BMAYxzZBxrr85etr9Ns7zL\nGTyYXI5BrEkbGdK6TUO8QWU+jUCRJU7x2+knSKLpk2wp0lk+YZZUkJrnxqnD/8ev\nDKL/8EVTYdgrr/ilxOpphiphFZ11+Y74Z5z0RtQc44rXnwVdVvz0LeaE5a1whE6s\n53wmDkaqNujyHXvA2g/Zxb+EslBl4673xMNucG//Q/aLyKe/RaRbCgoinKxSCzbK\naYL5qfXvy0MnTCOqlvC0ON51J51agGy4/ctnL5/+KnvGEI9kDDFDqzR6Wx+huIfs\n5WSpzcT5ysbX5xtGEe5yYHLYhuunl+cfDVEWVIEhQQKBgQD/c+tjcNPRMZDlDbgi\ntEiFbGbw/PogjVk/VHN/XCk1qnzYW++y0pmMef6LrJF5PEdWJ2gJZDEH8b3Z0Ct7\nwvJBZ7YiLTZRx0qQqOSy5IEQBf63hroeJY0ig9vlyg3Pv9Exu2lZyFLXYkrALeVi\nY9TRtPlML12WemiNE7IPeC7CyQKBgQDbtECKuT1ODLAELiSbleg0nYHWp3S0BTDb\n/W9aCFr0oG1nr3LRdLxfZuwglApENXG02tuOOrZOpAfmDQLXB8RpYK+vAM8HeTtg\nhzsz2SH0Q1ozZiK3rkojZkKrBTg1rlDTeWBqUTHUUTtUJVE1XQc1tDdgs1pYv7HL\nq5uUeQvDEQKBgFmOijeSlrAAcIvdA3EnQ0WDe5OBHS/MXj2VnehIpynpW1t+38oR\ni0N0gYj2NwoJ1/icWBzywz3FwolaMeRxs/y6H2Bb+W8yLzIIBCWzdovnjiVJVna7\nM3+mOrGU5MKwvOZyjbysPl7EVvCJJqIX3cSnbb8H3AelYoITJZnGyJ4BAoGAUsGs\n5hQsgW/KBWkUJP7sfpUtyRs+nGiwJM1r2i/3gtnDHCE8UKV2J0FvhD3/N/4hnIwr\n04FOFoU27HLONQ0Z8M+YnYTiduA1e4C0zizl20pbeazpOuMNzhPA3QaUS7QjgeTg\namu3J1CJ1oJP+pfWFWaSzXwBdhiO8jbr3ZtS0OECgYEA3iPPnzJQqnzzyTWY/rXh\nqqpLjgxWiox01pwlE85asx/MezbfTtQ9IA71BDXFZHs200vURrVUp6U5NSzdVZGy\nHOMqe99hjrG3Z3ZQyCRq2D/rMMPXamA4JbYtPWnXafwN6aN+7F6ukD95/NPA7KUf\nqS5WOt84QzYIdALTkQSBc6w=\n-----END PRIVATE KEY-----\n"",
          ""client_email"": ""firebase-adminsdk-drllr@authentication-v1-4e63f.iam.gserviceaccount.com"",
          ""client_id"": ""112290996831504679545"",
          ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
          ""token_uri"": ""https://oauth2.googleapis.com/token"",
          ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
          ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-drllr%40authentication-v1-4e63f.iam.gserviceaccount.com"",
          ""universe_domain"": ""googleapis.com""
        }";
        static string filepath = "";
        public static FirestoreDb? Database { get; private set; }

        public static void SetEnvironmentVariable()
        {
            filepath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
            File.WriteAllText(filepath, fireconfig);
            File.SetAttributes(filepath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            Database = FirestoreDb.Create("authentication-v1-4e63f");
            File.Delete(filepath);
        }
    }
}
