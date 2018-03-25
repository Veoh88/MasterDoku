package tests;

import com.vaadin.testbench.parallel.ParallelTest;
import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.openqa.selenium.chrome.ChromeDriver;

public class LoginTest extends ParallelTest {

    private static final String URL="http://localhost";
    private static final String PORT="8080";

    @Before
    public void setup() throws Exception {
        setDriver(new ChromeDriver());
        getDriver().get(URL+":"+PORT);
    }

    @After
    public void tearDown() throws Exception {
        getDriver().quit();
    }

    @Test
    public void testAdminLogin() {
        LoginElement loginView = $(LoginElement.class).first();
        String mainViewURL = loginView.login("admin", "admin");
        Assert.assertEquals(mainViewURL, "start");
    }

    @Test
    public void testUserLogin() {
        LoginElement loginView = $(LoginElement.class).first();
        String userViewURL = loginView.login("EngineerA", "1234");
        Assert.assertEquals(userViewURL, "userview");
    }
}
