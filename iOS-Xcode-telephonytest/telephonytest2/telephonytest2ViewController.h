//
//  telephonytest2ViewController.h
//  telephonytest2
//
//  Created by Jonathan Goldberger on 1/8/14.
//  Copyright (c) 2014 Jonathan Goldberger. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <CoreTelephony/CTCall.h>
#import <CoreTelephony/CTCallCenter.h>
#import <CoreTelephony/CTTelephonyNetworkInfo.h>
#import <CoreTelephony/CTCarrier.h>

@interface telephonytest2ViewController : UIViewController

- (IBAction)placeCall:(id)sender;
@property (weak, nonatomic) IBOutlet UILabel *callLabel;

@property (nonatomic, strong) CTCallCenter *callCenter;
@property (nonatomic, strong) CTTelephonyNetworkInfo *networkInfo;
@property (nonatomic, strong) CTCall *calls;
@property (nonatomic, strong) NSString *carrierName;

@end
