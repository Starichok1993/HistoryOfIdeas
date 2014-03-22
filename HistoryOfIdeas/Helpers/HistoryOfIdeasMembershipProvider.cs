using System;
using System.Web.Helpers;
using System.Web.Security;
using HistoryOfIdeas.BLL.Interface.Services;
using HistoryOfIdeas.DAL.Entity;
using HistoryOfIdeas.IoC.DependencyInjection;
using Ninject;

namespace HistoryOfIdeas.Helpers
{
    public class HistoryOfIdeasMembershipProvider : MembershipProvider
    {
        public IUserService UserService
        {
           //   get { return NinjectWebCommon.GetKernel().Get<IUserService>(); }
            get { return new HistoryOfIdeasKernel().Get<IUserService>(); }
        }

        public override bool ValidateUser(string email, string password)
            {
                bool isValid;

                try
                {
                    isValid = UserService.IsUserValid(email, password);
                }
                catch { isValid = false; }

                return isValid;
            }

            public override MembershipUser GetUser(string email, bool userIsOnline)
            {
                var user = UserService.GetUserByEmail(email);

                if (!ReferenceEquals(user, null))
                {
                    return new MembershipUser("HistoryOfIdeasMembershipProvider", null, null, user.Email, null, null,
                            false, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
                }
                return null;
            }

            public MembershipUser CreateUser(string email, string password, string name, string surname)
            {
                MembershipUser membershipUser = GetUser(email, false);

                if (membershipUser == null)
                {
                    UserService.CreateUser(new User
                    {
                        Surname = surname,
                        Name = name,
                        Email = email,
                        Password = Crypto.HashPassword(password),
                    });

                    //Roles.AddUserToRole(email, "User");

                    return GetUser(email, false);
                }

                return null;
            }


            /// <summary>
            /// other methodes will implmenent as needed
            /// </summary>
            #region

            public override string ApplicationName
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            public override bool ChangePassword(string username, string oldPassword, string newPassword)
            {
                throw new NotImplementedException();
            }

            public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
            {
                throw new NotImplementedException();
            }

            public override bool DeleteUser(string username, bool deleteAllRelatedData)
            {
                throw new NotImplementedException();
            }

            public override bool EnablePasswordReset
            {
                get { throw new NotImplementedException(); }
            }

            public override bool EnablePasswordRetrieval
            {
                get { throw new NotImplementedException(); }
            }

            public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
            {
                throw new NotImplementedException();
            }

            public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
            {
                throw new NotImplementedException();
            }

            public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
            {
                throw new NotImplementedException();
            }

            public override int GetNumberOfUsersOnline()
            {
                throw new NotImplementedException();
            }

            public override string GetPassword(string username, string answer)
            {
                throw new NotImplementedException();
            }

            public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
            {
                throw new NotImplementedException();
            }

            public override string GetUserNameByEmail(string email)
            {
                throw new NotImplementedException();
            }

            public override int MaxInvalidPasswordAttempts
            {
                get { throw new NotImplementedException(); }
            }

            public override int MinRequiredNonAlphanumericCharacters
            {
                get { throw new NotImplementedException(); }
            }

            public override int MinRequiredPasswordLength
            {
                get { throw new NotImplementedException(); }
            }

            public override int PasswordAttemptWindow
            {
                get { throw new NotImplementedException(); }
            }

            public override MembershipPasswordFormat PasswordFormat
            {
                get { throw new NotImplementedException(); }
            }

            public override string PasswordStrengthRegularExpression
            {
                get { throw new NotImplementedException(); }
            }

            public override bool RequiresQuestionAndAnswer
            {
                get { throw new NotImplementedException(); }
            }

            public override bool RequiresUniqueEmail
            {
                get { throw new NotImplementedException(); }
            }

            public override string ResetPassword(string username, string answer)
            {
                throw new NotImplementedException();
            }

            public override bool UnlockUser(string userName)
            {
                throw new NotImplementedException();
            }

            public override void UpdateUser(MembershipUser user)
            {
                throw new NotImplementedException();
            }

            public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
            {
                throw new NotImplementedException();
            }

            #endregion



        
    }
}