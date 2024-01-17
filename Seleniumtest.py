from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.action_chains import ActionChains
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC

import time

driver = webdriver.Edge()


def waitForElementToLoad(identifier: str):
    WebDriverWait(driver, 10).until(EC.presence_of_element_located((By.ID, identifier)))


def typeHuman(text: str, actions: ActionChains):
    for letter in text:
        actions.send_keys(letter)
        actions.pause(0.1)


def tabChain(count: int, actions: ActionChains):
    for _ in range(count):
        actions.send_keys(Keys.TAB)
        actions.pause(0.5)


def inloggen(username: str, password: str, actions: ActionChains):
    """
    Assuming the login page is loaded and the focus is on the username field.
    """
    typeHuman(username, actions)
    tabChain(1, actions)
    typeHuman(password, actions)
    tabChain(1, actions)
    actions.send_keys(Keys.ENTER)
    actions.pause(0.1)


def uitloggen():
    print("Uitloggen")
    actions = ActionChains(driver)
    actions.pause(5)

    tabChain(2, actions)

    actions.send_keys(Keys.ENTER)
    actions.pause(0.1)

    actions.perform()

    driver.maximize_window()
    waitForElementToLoad("root")


def main():
    driver.get("http://localhost:5173/login")

    driver.maximize_window()

    waitForElementToLoad("root")

    actions = ActionChains(driver)

    # Inloggen
    print("Inloggen...")
    tabChain(2, actions)
    inloggen("kees.r@gmail.com", "passkees", actions)
    actions.perform()

    driver.maximize_window()
    waitForElementToLoad("root")

    # Uitloggen
    uitloggen()
    
    # Naar onderzoekportaal gaan
    print("Navigatie naar onderzoekportaal")
    actions = ActionChains(driver)
    actions.pause(5)

    tabChain(2, actions)

    actions.send_keys(Keys.ENTER)
    actions.pause(0.1)

    actions.perform()

    driver.maximize_window()
    waitForElementToLoad("root")

    # Inloggen
    print("Inloggen")
    actions = ActionChains(driver)
    tabChain(1, actions)
    inloggen("kees.r@gmail.com", "passkees", actions)
    actions.perform()

    driver.maximize_window()
    waitForElementToLoad("root")

    # Naar bedrijvenportaal gaan
    print("Navigatie naar bedrijvenportaal")
    actions = ActionChains(driver)
    actions.pause(5)

    tabChain(3, actions)

    actions.send_keys(Keys.ENTER)
    actions.pause(0.1)

    actions.perform()

    driver.maximize_window()
    waitForElementToLoad("root")

    time.sleep(5)

    driver.quit()


if __name__ == "__main__":
    main()
