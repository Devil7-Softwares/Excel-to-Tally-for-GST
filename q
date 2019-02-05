[33mcommit 2c8c8d60b074d77eddbb0f9474e309b418b954de[m[33m ([m[1;36mHEAD -> [m[1;32mmaster[m[33m)[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Feb 5 17:29:24 2019 +0530

    Implement Combined Sales Entries Export
    
    Some users may have hundreds/thousands of sales invoices in one single day and maybe they want to keep all of them in one single entry. This feature helps to achieve this. It combines consecutive invoices in same day and for same party to one single voucher entry.
    
    * Implement Option to Combine Sales Entries
    * Allow the User to Specify RegEx for Retriving Integer from Invoice Number (NOTE: The RegEx must have a group named 'invoice' that gives Integer value from Invoice Number)

[33mcommit 8f418451453b7c05ce7f301d2b35bb315f0823b2[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Feb 5 17:00:19 2019 +0530

    Fix: Duplicate Items in "Missing Ledgers" Alert

[33mcommit 7db1cc0a352f8021450d739fade3cdc741255a05[m[33m ([m[1;31morigin/master[m[33m, [m[1;31morigin/HEAD[m[33m)[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Feb 4 17:31:36 2019 +0530

    Update Excel Templates

[33mcommit 73cddf585f11b96e4275207c756a1e8d93102e23[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Feb 4 17:31:24 2019 +0530

    Improve Sales & Purchase Entries Handling
    
    * Dont Depend on Alias to Find Party Using GSTIN
    * Use Parties List to Find Party Using Using Given Reference (Reference Can be Anything Like GSTIN or Ledger Name or Alias)
    * Fetch GSTIN from Sales Tax Number of Ledger Account if User Checked 'Tally Old Version'

[33mcommit 977c91364265fe9c0838b1ded85de396451b3434[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Feb 4 17:27:48 2019 +0530

    Override ToString Method in 'Party'

[33mcommit ffd9255415ce323206a8e35370333b4f5c779f67[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Jan 31 18:49:28 2019 +0530

    Move LedgerNames Editor to Tools Category

[33mcommit 8ab78a8e0ecce8afd54f09a926f05b1034b5bb80[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Jan 31 18:44:39 2019 +0530

    Add Custom XML Request Dialog (Helpful to Test XML Requests)

[33mcommit d4aa2673701ef9c9de71dae5a9d743c86b80dd67[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Jan 9 16:09:46 2019 +0530

    Bump Version to 2.2.1

[33mcommit 18a14ec9cf18ccd76953038106d0e69659be94f3[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Jan 9 15:47:58 2019 +0530

    Fix: Sales & Purchase Entries Not Being Sorted in Invoice Mode

[33mcommit 3076a1ebd93c2224b071425608bceb644dab8b83[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Jan 9 15:20:30 2019 +0530

    Upgrade to Devexpress 18.2

[33mcommit c1db602a1f7e57da7a7e63df5b493fdd7b1913a3[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Dec 28 16:27:18 2018 +0530

    Bump Version to 2.2.0

[33mcommit 4d8515d07bdbe442e0d5af2d76a5c91d263aaca3[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Dec 28 16:27:09 2018 +0530

    Implement Hyperlink Events for Super Tool Tips

[33mcommit 71745dc8a5df5f2c5e5a2c3c3d5f7b93e982beb7[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Dec 28 16:10:59 2018 +0530

    Enable Separator to Invoice Mode Checkbox

[33mcommit d093022a5a9ee4164c4eb106c128950f0659e995[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Dec 27 17:14:36 2018 +0530

    Check is data is imported before exporting XML

[33mcommit be9418872d3334b66084dbb9627eb0c7786e46ff[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Dec 27 17:09:54 2018 +0530

    Unify "Use Invoice No" Ribbon Item

[33mcommit 86ab66441748ead4532980be1a520106873f58dd[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Dec 27 17:04:09 2018 +0530

    Add Tool Tips to Buttons

[33mcommit 0f93ad60c9fe535ba96f90cd5983c43e790817a0[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Dec 27 16:22:10 2018 +0530

    Implement Using "INVOICENUMBER" tag for Reference Number
    
    This helps to fix #1

[33mcommit 152621c46210c143173b864a23904cf1e62f1fa7[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Dec 26 17:39:57 2018 +0530

    Implement Exporting Sales & Purchase Entries in Invoice Mode

[33mcommit 6a387d70e8cccb6e720e663cd40cc374713ff4c1[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Dec 26 16:37:56 2018 +0530

    Vouchers: Sort Entries to Match the Order in Tally

[33mcommit d9c9654f9a91e06367a70646777c3348f080afe9[m[33m ([m[1;33mtag: v2.1.0[m[33m)[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Oct 22 02:50:18 2018 +0530

    Update Installer Project: Add New Dependencies

[33mcommit ce4fa857bb018cef641a8ed37476f571c015ef21[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Oct 22 02:30:44 2018 +0530

    Bump Version to 2.1.0

[33mcommit 760ced4c10a09dfbae1e22459610cc237ba02121[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Oct 22 02:24:50 2018 +0530

    Fix Error: Remove Data Validation from Place of Supply Column

[33mcommit e533872a8b5b45289477e8fcd4b2367dc79b523c[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Oct 22 02:20:21 2018 +0530

    Revert "Party: Return Name of Party If GSTIN is Empty"
    
    This reverts commit 19279f675b980c15f31abee8cf7c99cbcb3a892d.

[33mcommit 0d17bf1a70eb9e9ce706a54dae1ed0e260154246[m[33m ([m[1;33mtag: v2.0.0[m[33m)[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 18 10:36:22 2018 +0530

    Bump Version to 2.0.0

[33mcommit 8058a250a89a97ec868e9ba6852310fa89aa373f[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 17 18:29:57 2018 +0530

    SalesEntries: Add LookupEdit to GSTIN Column

[33mcommit 19279f675b980c15f31abee8cf7c99cbcb3a892d[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 17 18:29:38 2018 +0530

    Party: Return Name of Party If GSTIN is Empty

[33mcommit 560e8c5bf264393d23b0774c23ffcea14cbce0bf[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 17 18:21:53 2018 +0530

    BankEntries: Add Lookup Edit for LedgerName Column

[33mcommit 64060da1e1df75edf69923a037f056b24a44465f[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 17 18:19:42 2018 +0530

    PurchaseEntries: Add LookUpEdit to LedgerName Column

[33mcommit a253ece864c3ca2f3f66ae16d0b4194c643957d7[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 17 18:00:36 2018 +0530

    Let the User to Define Place Of Supply for Each Entry in Purchase/Sales

[33mcommit f4910d3a13ccf2b7c3e88f2a32dcb6adc7b0fa21[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 17 17:33:19 2018 +0530

    Bank Entries: Implement Support for Multiple Entries

[33mcommit 974ec3fe3ea78a5742b890cb2c336f78a445aba1[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 17 16:42:50 2018 +0530

    Fix Errors On Rounding Off

[33mcommit 87e27520d69f12cbd3d5c58538cce6ca0ad6d6c7[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 17 16:15:53 2018 +0530

    Improve Purchase/Sales Entry Handling
     * Support Multiline Entries for Different Rates in One Voucher

[33mcommit 2ececaf29addd46b390bbb5bbd0c66c7b23faf90[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 17 16:14:46 2018 +0530

    VoucherEntry: Remove ReadOnly Specifier from 'Amount' Property

[33mcommit 3f0ac07b48cf9100ccc95f77ca64e937f62f9557[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 17 16:13:56 2018 +0530

    Sales Entry: Use Same Variable Names as Purchase Entry

[33mcommit 940935481e6c07068bd6613f9166115055485846[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 16 18:40:12 2018 +0530

    Show Progress Panel while Saving Template with Data

[33mcommit 21d9f1a1116be8256aebd294626e239a385d11fb[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 16 18:01:18 2018 +0530

    Fix LoadParties Function Ignoring Empty GSTIN Entries

[33mcommit 1126c4760ce8f6b84dfdec2b11acd5288beea406[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 16 17:57:26 2018 +0530

    Allow User to Save Parties Template With Existing Parties List

[33mcommit 5a7aa473c48d23bbe6e06bb37a99bd1b6c7a8219[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 16 17:09:26 2018 +0530

    Improve Ledger Reading in TallyIO

[33mcommit 082f29d0cd1eb44ed14b1e26eff87eaca0c1dd82[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 16 16:35:29 2018 +0530

    Use User Defined StateCode

[33mcommit b322f711c54c2d5bc0000c97bdf76d62d665aedd[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 16 00:32:28 2018 +0530

    Improve Entry Validations

[33mcommit 4104150fc029206f5dec1e17ae4394735f2bb15b[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 16 00:32:09 2018 +0530

    GSTIN Validator : Add Optional Parameter to Get Error Info from isValid Function

[33mcommit caae276aafd0e13ab52e110ff350f8d00838f1cf[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 16 00:14:40 2018 +0530

    Improve Data Reading Functions From Excel

[33mcommit c3dfa47c68d4a39ade455041d6d2471c20302482[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Oct 15 23:19:18 2018 +0530

    Show Progress Panel While Exporting

[33mcommit cc2275c4b25231da513ef1d2c6878ab3aa5afe5c[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Oct 15 22:30:23 2018 +0530

    Implement Bank Entries Import & Export Functions

[33mcommit 79f84253ef514a6fb53eb65e8d64e61fe48a64d7[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 12 17:48:22 2018 +0530

    Make String Comparison Non Case-Sensitive

[33mcommit 5ed1e161d23258a488f9bbecaa0646b8e292a3a0[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 12 17:40:40 2018 +0530

    Use 'Sales Exempted' Ledger for Zero-Rated Sales Entries

[33mcommit 5952196e748753332fe49f077ca1ca2cb1431921[m[33m ([m[1;33mtag: v1.0.0[m[33m)[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 12 00:27:02 2018 +0530

    Add Installer Project

[33mcommit 9f3838105513ee86891322ba7014508abb92ef5b[m
Author: Dineshkumar T <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 23:31:49 2018 +0530

    Create LICENSE

[33mcommit e25d3bc7e0b5b56f29e616b478493a52b18ec5e6[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 23:26:45 2018 +0530

    Fix Compiler Warning : Initialize Value

[33mcommit 5673193ce2304e51472530a399c629ab73d25499[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 23:26:15 2018 +0530

    Allow User to Change State Code

[33mcommit 6e7cc2fa3d76b5e9e8e77cf25562b0cbfc68f72a[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 23:21:23 2018 +0530

    Try to Parse PlaceOfSupply from given GSTIN

[33mcommit 516d851114eb08688e1b67b1f12875ab2f7d8028[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 23:18:39 2018 +0530

    Update Excel Templates

[33mcommit eac31b3a09fed62f9d2caf1dbb8c319058e04c9d[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 22:58:14 2018 +0530

    Set License Name

[33mcommit e8e6c8a2a7bd543cd382f080c91fc619bfcadd7b[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 22:56:18 2018 +0530

    Set Product Name

[33mcommit 22adb886e618c9ead7e33c98e71e6fe6137f4d57[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 22:54:43 2018 +0530

    Add About Page & Show it on FirstRun

[33mcommit 3d34180880ba9c0ec267b5b5033973b01325f5c0[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 22:45:14 2018 +0530

    Add Splash Screen

[33mcommit d94c1ecb2ab9f11a0f71d5356a0bd18833f5a73f[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 22:42:52 2018 +0530

    Rename Project

[33mcommit afd6b40bcf77c7e94d4d4727e25de2d4ead21b3c[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 22:40:50 2018 +0530

    Setup Application Assembly Signing

[33mcommit 8f8c9f09c65297276d8d169a7fbcba3c8e47b181[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 22:39:55 2018 +0530

    Setup Assembly Info

[33mcommit b9e54d0e3ddab82f1b3c398cc6a5831fa87bdfe3[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 22:13:56 2018 +0530

    Setup Ribbon

[33mcommit 137df86c128fe14ae74d1103906f65f04a137f80[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 22:12:09 2018 +0530

    Move Save Format Option to Tally Ribbon Page (Templates)

[33mcommit 7f6deacb576f1ac1d9b4bc476729fa210dc3fc32[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 21:21:39 2018 +0530

    Hide Ribbon Pages & Make Syncing Essential, Check & Show Missing Ledgers

[33mcommit 94ffbc2da48761ab123819ebd3c6eaba8826008b[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 18:33:41 2018 +0530

    Arrage Ribbon Pages & Controls

[33mcommit cc5afa4fd0c99bdfabaae1847973d8415c39a423[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 18:20:54 2018 +0530

    Skip Duplicate Parites from Loading & Show Message on Finish

[33mcommit fcd4f8bcc4372deae16004e2be9de8e8eeaf4503[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 18:10:14 2018 +0530

    Set Tax Ledger Name to Include Tax Type (Input/Output)

[33mcommit 32a51cb3da38842820bb38ca863b0f3a9334069a[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 18:08:22 2018 +0530

    Update Ledgers Format Editor Form

[33mcommit 9c39d0f639fd79bc1ea8f777b15cd4d88875995f[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 16:33:12 2018 +0530

    Implement XML Export to Tally from within Application

[33mcommit 523942bcb045681236bfb68554bc1d956bbae621[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 16:02:15 2018 +0530

    Add Refresh Button to Entries & Parties

[33mcommit 667b8cc800adc89fc7a5e752659fe5b6e35e8399[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 15:56:35 2018 +0530

    Show Error in Purchase Entries if LedgerName or GSTIN doesn't Exist in Tally Ledgers

[33mcommit 88eceb09034639f556dd298290209fb2ebc85271[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 15:49:28 2018 +0530

    Ignore Existing Entries while Exporting XML of Parties

[33mcommit f4e611e2224d300ac116431d550a56dbc7800072[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 15:44:36 2018 +0530

    Show Error on Parties if Party Ledger Already Exists

[33mcommit cb2c34bab39917c734b68a2454133c7fef1b43d0[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 15:44:12 2018 +0530

    Tally Sync : Load Only List Of Accounts

[33mcommit ff859c9569b3c837381e575ee5451e6047b8e535[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 15:22:50 2018 +0530

    Tally Sync : Uncomment Try Statement

[33mcommit 03825b845063b624b24982cf4d0081aaaece14bc[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 15:22:21 2018 +0530

    Tally Sync : Improve XML Reader & Disable Namespaces

[33mcommit 34ca20e484fc82ddc15e35029ce13c15b03fb5af[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 15:14:58 2018 +0530

    Arrange Entries

[33mcommit 83c497554f72182a819e5307839c9d8aefd3b109[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Thu Oct 11 15:14:13 2018 +0530

    Fix Debit & Credit Entries

[33mcommit adcf954f57bac519ee8866d511e8524cc9a28fd0[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 23:55:56 2018 +0530

    Implement Sales Entries Exporting

[33mcommit 0c8becd550313cac442948202e28347c9f6b1057[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 23:27:24 2018 +0530

    Implement Sales Entry Importing

[33mcommit e120d9b8f5cf5dd5cc8f7b3a9d125a253b7e64a5[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 23:13:39 2018 +0530

    Add 'CESS' Field to Sales Entry

[33mcommit a3d64e3dbc1ee21d637446947115f7b045153fb1[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 22:42:00 2018 +0530

    Add Sales Entry Object

[33mcommit 3344c2f9153f2a6086c9d52215b009e97f0991e6[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 18:23:34 2018 +0530

    Tally Sync : Implement Sync Function

[33mcommit f12614e971bfd8342552a9dea4dcd091c11c0100[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 17:59:16 2018 +0530

    Tally Sync : Add Required Functions

[33mcommit 11eadafadc4ebfbdcf1c39f1f52f6632e19c7314[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 17:56:50 2018 +0530

    Tally Sync : Add  Response Object

[33mcommit fdca32f7484f43b5931d95c39cd3058099612579[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 17:54:23 2018 +0530

    Tally Sync : Add Request Templates

[33mcommit b1aec7c495b74c7fe3a056641f12459bc3ac5b22[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 17:51:44 2018 +0530

    Tally Sync : Init - Add Controls

[33mcommit 120ba93309750f9b5e530f1691fd9ff491083c59[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 17:30:54 2018 +0530

    Make Ledger Names Dynamic

[33mcommit 5760e725aada1e68473253c3508603fc869fc519[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 16:42:17 2018 +0530

    Add XtraFormTemp Class

[33mcommit 349e17c1311a7fe06b21ec8f7aae6d1f891a6e50[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 16:19:48 2018 +0530

    Fix Rounding Issues & Allow User to Decide Which Values to Use

[33mcommit ebfc05be32358bc3ca754ab32fb94e74034de189[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 16:17:11 2018 +0530

    Fix Derp in SaveFormat Function

[33mcommit 454f0078fdd62a87873c86232799bf12abe338d0[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Wed Oct 10 13:14:20 2018 +0530

    Start Main Form Maximized

[33mcommit 5219285086c06ba5c0bcd14aabf1aa11fdcd26a2[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 9 22:12:38 2018 +0530

    Implement Purchase Entries Exporting

[33mcommit d70958dc5579be3100d15d3ed517e805fade7fbd[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 9 22:12:15 2018 +0530

    Update Purchase Entries Excel Template

[33mcommit 8363e67e7b951f83824b7f1e232dd2e6926c9330[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 9 22:11:31 2018 +0530

    Add Converter Function to Converty PurchaseEntries to Vouchers

[33mcommit 767965bcd4cc9b91b740b4bc8b8cc560fc4e79a2[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 9 22:10:37 2018 +0530

    Add 'Voucher Entry' & 'Voucher' Objects

[33mcommit 66fc847b1174d184fbe0ce8bff394f80232c8ce1[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 9 22:09:36 2018 +0530

    Add 'Effect' Enum

[33mcommit 8807421752295d56e75d6efa9f2ffed85a4e3680[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Tue Oct 9 22:09:04 2018 +0530

    Fix Spelling for Journal in Voucher Types

[33mcommit b82fd414de11103fcb65f1ac8c5e875b45c6dd83[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Oct 8 17:02:49 2018 +0530

    Implemnt 'PurchaseEntries' Page

[33mcommit d46688edcddf9ae6b9c0f294a6b8c854e51882c0[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Oct 8 15:23:44 2018 +0530

    Sync Pages on TabControl and Ribbon

[33mcommit bc3a90e9ec1c91b73851daa3a940bd1ca626a03f[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Mon Oct 8 15:18:53 2018 +0530

    Implement Exporting 'Parties' to XML

[33mcommit 0ee10531037125500057ee9e34291fe1e86d44a5[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 17:53:27 2018 +0530

    Update LoadParties Function to Load Registration Type

[33mcommit d37d6787d8eb642f0cae48e2d1fea949afeeb556[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 17:48:45 2018 +0530

    Add 'RegistrationType' Property to 'Party'

[33mcommit 0bf5d1363b4a376bfd156bae24fade7993a82626[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 16:36:51 2018 +0530

    Add 'State' Property to 'Party'

[33mcommit d7869e0de6b9b4019007b2c077a101c8770cf8b1[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 16:35:05 2018 +0530

    Add 'State' Object & States, GST State Codes List

[33mcommit 3a6318784ce44a94fa8180a74d4eec48ebf76d89[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 16:20:34 2018 +0530

    Validate GSTIN of Party and Show Warnings

[33mcommit 8ce369479efaa450f0cab65e341a4d1e34a5d184[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 16:20:13 2018 +0530

    Improve GSTIN Validator

[33mcommit d5d0a3ca6cf9c2772a356c1dd02b5c52ebc42742[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 15:58:19 2018 +0530

    Add GSTIN Validator

[33mcommit cc1394cc25693975ef214574a4b10d2baef82d79[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 15:56:25 2018 +0530

    Implement Loading Parties from Excel

[33mcommit 2c38f801fb2457bb9eadd02b96523befd62581ea[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 13:17:16 2018 +0530

    Setup MainForm, Add 'Party' Object

[33mcommit ffa3fc06f709588179bb0cd83c99b39420b24a8d[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 13:01:00 2018 +0530

    Use RibbonForm for MainForm

[33mcommit ad026425ab37f5b5bdfe78e43201b42437fc70fe[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 12:56:06 2018 +0530

    Add project files.

[33mcommit 094c10b6633c988ae2cf2102443ea6a834a0a907[m
Author: Devil7DK <dineshthangavel47@gmail.com>
Date:   Fri Oct 5 12:56:00 2018 +0530

    Add .gitignore and .gitattributes.
