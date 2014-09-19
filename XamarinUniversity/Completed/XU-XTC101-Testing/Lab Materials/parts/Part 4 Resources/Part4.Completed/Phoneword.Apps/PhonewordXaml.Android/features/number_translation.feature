Feature: Number translation
  Alphanumeric phone numbers must translate to their numeric equivalents

  Scenario: Translate the Xamarin number
    Given I use the native keyboard to enter "1-855-XAMARIN" into text field number 1
    And I touch the "Translate" button
    Then I see the text "Call 1-855-9262746"