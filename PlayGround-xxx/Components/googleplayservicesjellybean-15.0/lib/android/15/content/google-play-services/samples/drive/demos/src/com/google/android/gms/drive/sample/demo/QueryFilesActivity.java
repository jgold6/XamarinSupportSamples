/**
 * Copyright 2013 Google Inc. All Rights Reserved.
 *
 *  Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except
 * in compliance with the License. You may obtain a copy of the License at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.google.android.gms.drive.sample.demo;

import android.os.Bundle;
import android.widget.ListView;

import com.google.android.gms.common.api.ResultCallback;
import com.google.android.gms.drive.Drive;
import com.google.android.gms.drive.DriveApi.MetadataBufferResult;
import com.google.android.gms.drive.query.Filters;
import com.google.android.gms.drive.query.Query;
import com.google.android.gms.drive.query.SearchableField;

/**
 * An activity to illustrate how to query files.
 */
public class QueryFilesActivity extends BaseDemoActivity {

    private ListView mResultsListView;
    private ResultsAdapter mResultsAdapter;

    @Override
    protected void onCreate(Bundle b) {
        super.onCreate(b);
        setContentView(R.layout.activity_listfiles);
        mResultsListView = (ListView) findViewById(R.id.listViewResults);
        mResultsAdapter = new ResultsAdapter(this);
        mResultsListView.setAdapter(mResultsAdapter);
    }

    @Override
    public void onConnected(Bundle connectionHint) {
        super.onConnected(connectionHint);
        Query query = new Query.Builder()
                .addFilter(Filters.eq(SearchableField.MIME_TYPE, "text/plain"))
                .build();
        Drive.DriveApi.query(getGoogleApiClient(), query)
                .setResultCallback(metadataCallback);
    }

    final private ResultCallback<MetadataBufferResult> metadataCallback = new
            ResultCallback<MetadataBufferResult>() {
        @Override
        public void onResult(MetadataBufferResult result) {
            if (!result.getStatus().isSuccess()) {
                showMessage("Problem while retrieving results");
                return;
            }
            mResultsAdapter.clear();
            mResultsAdapter.append(result.getMetadataBuffer());
        }
    };
}
