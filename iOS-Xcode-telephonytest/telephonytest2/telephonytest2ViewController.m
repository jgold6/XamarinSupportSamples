//
//  telephonytest2ViewController.m
//  telephonytest2
//
//  Created by Jonathan Goldberger on 1/8/14.
//  Copyright (c) 2014 Jonathan Goldberger. All rights reserved.
//

#import "telephonytest2ViewController.h"

@interface telephonytest2ViewController ()

@end

@implementation telephonytest2ViewController

@synthesize callCenter, calls, networkInfo, carrierName;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
    networkInfo = [[CTTelephonyNetworkInfo alloc] init];
    callCenter = [[CTCallCenter alloc] init];
    carrierName = [[networkInfo subscriberCellularProvider] carrierName];
    
    
    callCenter.callEventHandler=^(CTCall* call)
    {
        NSLog(@"Call event: %@", [call callState]);
        
    };
  
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}
// With telprompt
- (IBAction)placeCall:(id)sender {
    
    if ([[UIApplication sharedApplication] canOpenURL:[NSURL URLWithString:@"telprompt://5415055241"]]) {
        [[UIApplication sharedApplication] openURL:[NSURL URLWithString:@"telprompt://5415055241"]];
    } else {
        UIAlertView *av = [[UIAlertView alloc] initWithTitle:@"No Phone" message:@"" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil];
        [av show];
    }
}
// With tel
//- (IBAction)placeCall:(id)sender {
//    
//    if ([[UIApplication sharedApplication] canOpenURL:[NSURL URLWithString:@"tel://5415055241"]]) {
//        [[UIApplication sharedApplication] openURL:[NSURL URLWithString:@"tel://5415055241"]];
//    } else {
//        UIAlertView *av = [[UIAlertView alloc] initWithTitle:@"No Phone" message:@"" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil];
//        [av show];
//    }
//}

@end







































