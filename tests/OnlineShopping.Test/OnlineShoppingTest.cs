using System.Runtime.InteropServices;
using Xunit;

namespace OnlineShopping.Test
{
    public class OnlineShoppingTest
    {
        [Fact]
        public void ApproveSwitchStore()
        {
            /*
             * 1. Fix the setup of this test so that it can run
             * 2. Use Approvals to verify the OnlineShopping instance
             * 3. Check the received file, modify any necessary ToString methods until you are happy with the output
             * 4. Approve the new output
             * 5. Re-run the test to make sure it is now green
             * 6. Convert your approvals test into a combination approvals test. Use a single combination initially
             * 7. Run the test and inspect the output
             * 8. Add more combinations until all branches are fully covered
             * 9. Test mutations by modifying parts of the production code. Do your tests fail when you break production code?
             */
            Session session = null;
            OnlineShopping onlineShopping = new OnlineShopping(session);
            Store storeToSwitchTo = null;
            onlineShopping.SwitchStore(storeToSwitchTo);
        }
    }
}