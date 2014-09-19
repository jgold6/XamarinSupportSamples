/*
 * Copyright (C) 2012 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.google.android.gms.samples.wallet;

import android.annotation.TargetApi;
import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;

/**
 * Item details page.
 */
public class ItemDetailsActivity extends FragmentActivity {
    private Menu mMenu;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_item_details);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        switch (requestCode) {
            case LoginActivity.REQUEST_USER_LOGIN:
                if (resultCode == RESULT_OK) {
                    invalidateOptionsMenu();
                }
                break;
            default:
                super.onActivityResult(requestCode, resultCode, data);
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        super.onCreateOptionsMenu(menu);

        mMenu = menu;
        MenuInflater inflater = getMenuInflater();
        if (((XyzApplication) getApplication()).isLoggedIn()) {
            inflater.inflate(R.menu.menu_logout, menu);
        } else {
            inflater.inflate(R.menu.menu_login, menu);
        }

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.login:
                Intent intent = new Intent(this, LoginActivity.class);
                startActivityForResult(intent, LoginActivity.REQUEST_USER_LOGIN);
                return true;
            case R.id.logout:
                ((XyzApplication) getApplication()).logout();
                invalidateOptionsMenu();
                return true;
            default:
                return false;
        }
    }

    @Override
    @TargetApi(11)
    public void invalidateOptionsMenu() {
        // Activity.invalidateOptionsMenu() is a useful method to rebuild the menu object but it
        // was not added until Gingerbread. We'll use it if it's available on the platform.
        if (Build.VERSION.SDK_INT >= 11) {
            super.invalidateOptionsMenu();
        } else if (mMenu != null) {
            MenuInflater inflater = getMenuInflater();
            if (((XyzApplication) getApplication()).isLoggedIn()) {
                inflater.inflate(R.menu.menu_logout, mMenu);
            } else {
                inflater.inflate(R.menu.menu_login, mMenu);
            }
        }
    }

}
