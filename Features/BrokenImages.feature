Feature: BrokenImages
	Simple http call and find broken images count

@mytag
Scenario: Broken images count
	Given open http call
	When count broken images in page
	Then write broken images count