USE master

DECLARE @RecordCounts TABLE (TableName NVARCHAR(250), RecordCount BIGINT);

-- AnaCreditInstrumentType
DELETE FROM LRDW_DataVault.LrdwVault.R_AnaCreditInstrumentType

MERGE INTO LRDW_DataVault.LrdwVault.R_AnaCreditInstrumentType
USING (SELECT Code, Name FROM StaticDataDepot.LRDW_Reference_Data.AnaCreditInstrumentType) src
ON AnaCreditInstrumentType_Code = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (AnaCreditInstrumentType_Code, AnaCreditInstrumentType_Name, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (Code, Name, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_AnaCreditInstrumentType', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_AnaCreditInstrumentType;

-- CalculationRuleDefinition
MERGE INTO LRDW_DataVault.LrdwVault.R_CalculationRuleDefinition
USING (SELECT Code FROM StaticDataDepot.LRDW_Reference_Data.CalculationRuleDefinition) src
ON RuleCode_BK = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (RuleCode_BK, LoadDate, ProcessLogSeqID)
		VALUES (Code, GETUTCDATE(), 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_CalculationRuleDefinition', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_CalculationRuleDefinition;

DELETE FROM LRDW_DataVault.LrdwVault.RS_CalculationRuleDefinition

DECLARE @t TABLE (BK1 NVARCHAR(250), BK2 NVARCHAR(250), BK3 NVARCHAR(250), SeqId BIGINT);
INSERT INTO @t (BK1, SeqId) SELECT RuleCode_BK, R_CalculationRuleDefinition_Seq_ID FROM LRDW_DataVault.LrdwVault.R_CalculationRuleDefinition;

WITH SourceCte AS
(
	SELECT t.SeqId, Name, LiquidityGroup, LiquidityProduct, IssuerCounterpartyType, IssuerResidenceCountryCode, CounterpartyType, InstrumentNormalisedRating, SecurityType, GuarantorCounterpartyType, InputAmountFactor, LedgerCode, DerivedAffiliateEntityCode, GBSGroupDivision, AmountProduct, AccountingMethodCode, ForwardStarting30DIndicator_ID, ForwardStarting30DIndicator_Code, ForwardStarting30DIndicator_Name, MaturingIndicator_ID, MaturingIndicator_Code, MaturingIndicator_Name, CashFlowMaturingIndicator_ID, CashFlowMaturingIndicator_Code, CashFlowMaturingIndicator_Name, PerformingIndicator_ID, PerformingIndicator_Code, PerformingIndicator_Name, RevocableIndicator_ID, RevocableIndicator_Code, RevocableIndicator_Name, EEAIndicator_ID, EEAIndicator_Code, EEAIndicator_Name, AssetTypeLevelBaselIII_ID, AssetTypeLevelBaselIII_Code, AssetTypeLevelBaselIII_Name, InternalRating_ID, InternalRating_Code, InternalRating_Name, AssetTypeLevel_ID, AssetTypeLevel_Code, AssetTypeLevel_Name, FacilityRevolvingIndicator_ID, FacilityRevolvingIndicator_Code, FacilityRevolvingIndicator_Name, IssuerEEAIndicator_ID, IssuerEEAIndicator_Code, IssuerEEAIndicator_Name, ECAIRating_ID, ECAIRating_Code, ECAIRating_Name, InstrumentECBEligibility_ID, InstrumentECBEligibility_Code, InstrumentECBEligibility_Name, GuarantorEEAIndicator_ID, GuarantorEEAIndicator_Code, GuarantorEEAIndicator_Name, ContractualCashflowUsableIndicator_ID, ContractualCashflowUsableIndicator_Code, ContractualCashflowUsableIndicator_Name, AmountSignage_ID, AmountSignage_Code, AmountSignage_Name, CalculationAmountClass_ID, CalculationAmountClass_Code, CalculationAmountClass_Name, EliminationRole_ID, EliminationRole_Code, EliminationRole_Name 
	FROM StaticDataDepot.LRDW_Reference_Data.CalculationRuleDefinition s
	JOIN @t t ON t.BK1 = s.Code
)
MERGE INTO LRDW_DataVault.LrdwVault.RS_CalculationRuleDefinition
USING SourceCte AS src
ON R_CalculationRuleDefinition_Seq_ID = src.SeqId
WHEN NOT MATCHED
	THEN
		INSERT (R_CalculationRuleDefinition_Seq_ID, LoadDate, LoadEndDate, ProcessLogSeqID, CheckSumvalue, Voided)
		VALUES (SeqId, GETUTCDATE(), '99991231', 1, SeqId, 0);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'RS_CalculationRuleDefinition', COUNT(*) FROM LRDW_DataVault.LrdwVault.RS_CalculationRuleDefinition;

-- R_CfroDashboard
MERGE INTO LRDW_DataVault.LrdwVault.R_CfroDashboard
USING (SELECT Code, Name, CfroSectionLevel1, CfroSectionLevel2, CfroLabelDescription, CfroTooltipDescription FROM StaticDataDepot.LRDW_Reference_Data.CfroDashboard) src
ON CfroDashboard_BK = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (CfroDashboard_BK, Name, CfroSectionLevel1, CfroSectionLevel2, CfroLabelDescription, CfroTooltipDescription, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (Code, Name, CfroSectionLevel1, CfroSectionLevel2, CfroLabelDescription, CfroTooltipDescription, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_CfroDashboard', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_CfroDashboard;

-- DomainLayerValueMapping
MERGE INTO LRDW_DataVault.LrdwVault.R_DomainLayerValueMapping
USING (SELECT SourceDomain_Code, TargetDomainLayer_Code, SourceDomainValue_Code, SourceDomainValue_Name, TargetValue FROM StaticDataDepot.LRDW_Reference_Data.DomainLayerValueMapping) src
ON SourceDomain = src.SourceDomain_Code AND TargetDomainLayer = src.TargetDomainLayer_Code AND SourceDomainValueKey = src.SourceDomainValue_Code
WHEN NOT MATCHED
	THEN
		INSERT (SourceDomain, TargetDomainLayer, SourceDomainValueKey, SourceDomainValue, TargetValue, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (SourceDomain_Code, TargetDomainLayer_Code, SourceDomainValue_Code, SourceDomainValue_Name, TargetValue, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_DomainLayerValueMapping', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_DomainLayerValueMapping;

-- DomainValue
DELETE FROM LRDW_DataVault.LrdwVault.R_DomainValue

MERGE INTO LRDW_DataVault.LrdwVault.R_DomainValue
USING (SELECT Domain_Code, Layer_Code, Code, Value FROM StaticDataDepot.LRDW_Reference_Data.DomainValue) src
ON Domain = src.Domain_Code AND Layer = src.Layer_Code AND ValueKey = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (Domain, Layer, ValueKey, Value, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (Domain_Code, Layer_Code, Code, Value, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_DomainValue', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_DomainValue;

-- EbaCustomerTypeMapping
DELETE FROM LRDW_DataVault.LrdwVault.R_EbaCustomerTypeMapping

MERGE INTO LRDW_DataVault.LrdwVault.R_EbaCustomerTypeMapping tgt
USING (SELECT Code, Name, CustomerType FROM StaticDataDepot.LRDW_Reference_Data.EbaCustomerTypeMapping) src
ON EBASectorCode = src.Code AND tgt.CustomerType = src.CustomerType
WHEN NOT MATCHED
	THEN
		INSERT (EBASectorCode, EBASectorName, CustomerType, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (Code, Name, CustomerType, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_EbaCustomerTypeMapping', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_EbaCustomerTypeMapping;

-- EbaCustomerTypeMapping
DELETE FROM LRDW_DataVault.LrdwVault.R_EntityPrefixes

MERGE INTO LRDW_DataVault.LrdwVault.R_EntityPrefixes tgt
USING (SELECT Code, BranchFileLevel_Code, Prefix, PrefixToAdd FROM StaticDataDepot.LRDW_Reference_Data.EntityPrefixes) src
ON EntityCode = src.Code AND BranchFileLevel = src.BranchFileLevel_Code AND tgt.Prefix = src.Prefix
WHEN NOT MATCHED
	THEN
		INSERT (EntityCode, BranchFileLevel, Prefix, PrefixToAdd, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, src.BranchFileLevel_Code, Prefix, PrefixToAdd, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_EntityPrefixes', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_EntityPrefixes;

-- ExportTypeMapping
DELETE FROM LRDW_DataVault.LrdwVault.R_ExportTypeMapping

MERGE INTO LRDW_DataVault.LrdwVault.R_ExportTypeMapping tgt
USING (SELECT Code, Context_Code, ReportType_Code, ExportType_Code, ExportFolder_Code, ExportPackageName_Code FROM StaticDataDepot.LRDW_Reference_Data.ExportTypeMapping) src
ON ExportTypeMapping_BK = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (ExportTypeMapping_BK, Context_Code, ReportType_Code, ExportType_Code, ExportFolder_Code, ExportPackageName_Code, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, src.Context_Code, src.ReportType_Code, src.ExportType_Code, src.ExportFolder_Code, src.ExportPackageName_Code, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_ExportTypeMapping', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_ExportTypeMapping;

-- FinanceProduct
DELETE FROM LRDW_DataVault.LrdwVault.R_FinanceProduct

MERGE INTO LRDW_DataVault.LrdwVault.R_FinanceProduct tgt
USING (SELECT Code, BranchProduct_Code, IIF(DuplicateProductExclusionIndicator_Code = 'Y', 1, 0) AS DuplicateProductExclusionIndicator, CreditCommittedIndicator_Code, FiduciaryIndicator_Code, RepaymentRightsIndicator_Code, AnaCreditInstrumentType_Code, DiscountedProductTypeCode, StartDateSelection FROM StaticDataDepot.LRDW_Reference_Data.FinanceProduct) src
ON FinanceProduct_Code = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (FinanceProduct_Code, BranchProduct_Code, DuplicateProductExclusionIndicator, CreditCommittedIndicator_Code, FiduciaryIndicator_Code, RepaymentRightsIndicator_Code, AnaCreditInstrumentType_Code, DiscountedProductTypeCode, StartDateSelection, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, src.BranchProduct_Code, src.DuplicateProductExclusionIndicator, src.CreditCommittedIndicator_Code, src.FiduciaryIndicator_Code, src.RepaymentRightsIndicator_Code, src.AnaCreditInstrumentType_Code, src.DiscountedProductTypeCode, src.StartDateSelection, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_FinanceProduct', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_FinanceProduct;

-- GlobalRelationWWID
DELETE FROM LRDW_DataVault.LrdwVault.R_GlobalRelationWWID

MERGE INTO LRDW_DataVault.LrdwVault.R_GlobalRelationWWID tgt
USING (SELECT Code, Name, [RIAD Code Observed Agent] FROM StaticDataDepot.LRDW_Reference_Data.GlobalRelationWWID) src
ON WWID = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (WWID, GlobalRelationName, RIADCodeObservedAgent, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, src.Name, src.[RIAD Code Observed Agent], GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_GlobalRelationWWID', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_GlobalRelationWWID;

-- InternalRelationLinking
DELETE FROM LRDW_DataVault.LrdwVault.RS_KondorDealPrefix

MERGE INTO LRDW_DataVault.LrdwVault.R_KondorDealPrefix tgt
USING (SELECT SourceSystem_Code, DealNumberPrefix FROM StaticDataDepot.LRDW_Reference_Data.KondorDealPrefix) src
ON SourceSystem_BK = SourceSystem_Code AND DealNumberPrefix_BK = DealNumberPrefix
WHEN NOT MATCHED
	THEN
		INSERT (SourceSystem_BK, DealNumberPrefix_BK, LoadDate, ProcessLogSeqID)
		VALUES (src.SourceSystem_Code, src.DealNumberPrefix, GETUTCDATE(), 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_KondorDealPrefix', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_KondorDealPrefix;

DELETE FROM @t
INSERT INTO @t (BK1, BK2, SeqId) SELECT SourceSystem_BK, DealNumberPrefix_BK, R_KondorDealPrefix_Seq_ID FROM LRDW_DataVault.LrdwVault.R_KondorDealPrefix;

MERGE INTO LRDW_DataVault.LrdwVault.RS_KondorDealPrefix tgt
USING (
	SELECT t.SeqId, SourceSystem_Code, DealNumberPrefix, DerivedFODealNumberPrefix1, DerivedFODealNumberPrefix2 
	FROM StaticDataDepot.LRDW_Reference_Data.KondorDealPrefix
	JOIN @t t ON t.BK1 = SourceSystem_Code AND t.BK2 = DealNumberPrefix
) src
ON R_KondorDealPrefix_Seq_ID = src.SeqId
WHEN NOT MATCHED
	THEN
		INSERT (R_KondorDealPrefix_Seq_ID, DerivedFODealNumberPrefix1, DerivedFODealNumberPrefix2 , LoadDate, LoadEndDate, ProcessLogSeqID, CheckSumvalue, Voided)
		VALUES (src.SeqId, src.DerivedFODealNumberPrefix1, src.DerivedFODealNumberPrefix2 , GETUTCDATE(), '99991231', 1, src.SeqId, 0);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'RS_KondorDealPrefix', COUNT(*) FROM LRDW_DataVault.LrdwVault.RS_KondorDealPrefix;

-- LegalForm
DELETE FROM LRDW_DataVault.LrdwVault.R_LegalForm

MERGE INTO LRDW_DataVault.LrdwVault.R_LegalForm tgt
USING (SELECT Code, CountryOfResidence, LegalFormCode, AnaCreditLegalFormCode, IIF(GDPRMaskingFlag_Code = 'Y', 1, 0) AS GDPRMaskingFlag FROM StaticDataDepot.LRDW_Reference_Data.LegalForm) src
ON LegalFormKeyCode = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (LegalFormKeyCode, CountryOfResidence, LegalFormCode, AnaCreditLegalFormCode, GDPRMaskingFlag, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, src.CountryOfResidence, src.LegalFormCode, src.AnaCreditLegalFormCode, src.GDPRMaskingFlag, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_LegalForm', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_LegalForm;

-- LiquidityProductMapping
--DELETE FROM LRDW_DataVault.LrdwVault.R_Liquidity

--MERGE INTO LRDW_DataVault.LrdwVault.R_Liquidity tgt
--USING (SELECT LiquidityProduct_Code, FinanceProduct_Code, Signage_Code FROM StaticDataDepot.LRDW_Reference_Data.LiquidityProductMapping) src
--ON LegalFormKeyCode = src.Code
--WHEN NOT MATCHED
--	THEN
--		INSERT (LegalFormKeyCode, CountryOfResidence, LegalFormCode, AnaCreditLegalFormCode, GDPRMaskingFlag, LoadDate, LoadEndDate, ProcessLogSeqID)
--		VALUES (src.Code, src.CountryOfResidence, src.LegalFormCode, src.AnaCreditLegalFormCode, src.GDPRMaskingFlag, GETUTCDATE(), '99991231', 1);

-- LQAClassificationMapping
DELETE FROM LRDW_DataVault.LrdwVault.R_LQAClassificationMapping

MERGE INTO LRDW_DataVault.LrdwVault.R_LQAClassificationMapping tgt
USING (SELECT LQAClassification_Code, LQAClassification_Name, StatusOfForbearanceAndRenegotiation_Code, StatusOfForbearanceAndRenegotiation_Name FROM StaticDataDepot.LRDW_Reference_Data.LQAClassificationMapping) src
ON tgt.LQAClassification_Code = src.LQAClassification_Code AND tgt.StatusOfForbearanceAndRenegotiation_Code = src.StatusOfForbearanceAndRenegotiation_Code
WHEN NOT MATCHED
	THEN
		INSERT (LQAClassification_Code, LQAClassification_Name, StatusOfForbearanceAndRenegotiation_Code, StatusOfForbearanceAndRenegotiation_Name, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.LQAClassification_Code, src.LQAClassification_Name, src.StatusOfForbearanceAndRenegotiation_Code, src.StatusOfForbearanceAndRenegotiation_Name, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_LQAClassificationMapping', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_LQAClassificationMapping;

-- LQAModificationMapping
DELETE FROM LRDW_DataVault.LrdwVault.R_LQAModificationMapping

MERGE INTO LRDW_DataVault.LrdwVault.R_LQAModificationMapping tgt
USING (SELECT LQAModification_Code, LQAModification_Name, StatusOfForbearanceAndRenegotiation_Code, StatusOfForbearanceAndRenegotiation_Name FROM StaticDataDepot.LRDW_Reference_Data.LQAModificationMapping) src
ON tgt.LQAModification_Code = src.LQAModification_Code AND tgt.StatusOfForbearanceAndRenegotiation_Code = src.StatusOfForbearanceAndRenegotiation_Code
WHEN NOT MATCHED
	THEN
		INSERT (LQAModification_Code, LQAModification_Name, StatusOfForbearanceAndRenegotiation_Code, StatusOfForbearanceAndRenegotiation_Name, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.LQAModification_Code, src.LQAModification_Name, src.StatusOfForbearanceAndRenegotiation_Code, src.StatusOfForbearanceAndRenegotiation_Name, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_LQAModificationMapping', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_LQAModificationMapping;

-- MaturityBucket
DELETE FROM LRDW_DataVault.LrdwVault.R_MaturityBucket

MERGE INTO LRDW_DataVault.LrdwVault.R_MaturityBucket tgt
USING (SELECT Code, Schema_Code, Name, FirstDayInBucketDate_Code, FirstDayInBucketDate_Name, FirstDayInBucketMonths, FirstDayInBucketDays, LastDayInBucketDate_Code, LastDayInBucketDate_Name, LastDayInBucketMonths, LastDayInBucketDays, Schema_Name, SortOrder FROM StaticDataDepot.LRDW_Reference_Data.MaturityBucket) src
ON tgt.MaturityBucket = src.Code AND tgt.MaturitySchema = src.Schema_Code
WHEN NOT MATCHED
	THEN
		INSERT (MaturityBucket, MaturitySchema, MaturityBucketName, FirstDayInBucketDate, FirstDayInBucketDateName, FirstDayInBucketMonths, FirstDayInBucketDays, LastDayInBucketDate, LastDayInBucketDateName, LastDayInBucketMonths, LastDayInBucketDays, MaturitySchemaName, SortOrder, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, Schema_Code, Name, FirstDayInBucketDate_Code, FirstDayInBucketDate_Name, FirstDayInBucketMonths, FirstDayInBucketDays, LastDayInBucketDate_Code, LastDayInBucketDate_Name, LastDayInBucketMonths, LastDayInBucketDays, Schema_Name, SortOrder, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_MaturityBucket', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_MaturityBucket;

-- NationalIdentifier
DELETE FROM LRDW_DataVault.LrdwVault.R_NationalIdentifier

MERGE INTO LRDW_DataVault.LrdwVault.R_NationalIdentifier tgt
USING (SELECT Code, Name FROM StaticDataDepot.LRDW_Reference_Data.NationalIdentifier) src
ON tgt.WWID_BK = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (WWID_BK, NationalIdentifier, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, src.Name, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_NationalIdentifier', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_NationalIdentifier;

-- NationalIdentifiersToSuppress
DELETE FROM LRDW_DataVault.LrdwVault.R_NationalIdentifiersToSuppress

MERGE INTO LRDW_DataVault.LrdwVault.R_NationalIdentifiersToSuppress tgt
USING (SELECT Code, Reason FROM StaticDataDepot.LRDW_Reference_Data.NationalIdentifiersToSuppress) src
ON tgt.NationalIdentifier_BK = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (NationalIdentifier_BK, Reason, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, src.Reason, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_NationalIdentifiersToSuppress', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_NationalIdentifiersToSuppress;

-- PrivateCompany
DELETE FROM LRDW_DataVault.LrdwVault.R_PrivateCompany

MERGE INTO LRDW_DataVault.LrdwVault.R_PrivateCompany tgt
USING (SELECT Code, Name FROM StaticDataDepot.LRDW_Reference_Data.PrivateCompany) src
ON tgt.AnaCreditLegalFormCode = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (AnaCreditLegalFormCode, Name, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, src.Name, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_PrivateCompany', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_PrivateCompany;

-- ReportingEntity
DELETE FROM LRDW_DataVault.LrdwVault.R_ReportingEntity

MERGE INTO LRDW_DataVault.LrdwVault.R_ReportingEntity tgt
USING (SELECT Name, Code, Region_Code, IIF(OnboardedIndicator_Code='Y',1,0) AS OnboardedIndicator, IIF(CashflowUsageIndicator_Code = 'Y',1,0) AS CashflowUsageIndicator, IIF([5028EnabledIndicator_Code]='Y',1,0) AS [5028Enabledindicator], GlobalRelationWWID_Code, IIF(CFRODashboardNotApplicableIndicator_Code='Y',1,0) AS CFRODashboardNotApplicableIndicator, CFRODashboardValidFrom, CFRODashboardValidTo, IIF(ProcessCube_Code='Y',1,0) AS ProcessCube, Branch, NextInterestPaymentDateMethod FROM StaticDataDepot.LRDW_Reference_Data.ReportingEntity) src
ON tgt.Code = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (Name, Code, Region, OnboardedIndicator, CashflowUsageIndicator, [5028Enabledindicator], GlobalRelationWWID, CFRODashboardNotApplicableIndicator, CFRODashboardValidFrom, CFRODashboardValidTo, ProcessCube, Branch, NextInterestPaymentDateMethod, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Name, Code, Region_Code, OnboardedIndicator, CashflowUsageIndicator, [5028Enabledindicator], GlobalRelationWWID_Code, CFRODashboardNotApplicableIndicator, CFRODashboardValidFrom, CFRODashboardValidTo, ProcessCube, Branch, NextInterestPaymentDateMethod, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_ReportingEntity', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_ReportingEntity;

-- ReportType
DELETE FROM LRDW_DataVault.LrdwVault.R_ReportType

MERGE INTO LRDW_DataVault.LrdwVault.R_ReportType tgt
USING (SELECT Code, CalculationActiveIndicator_Code, StartDate, EndDate, MaturitySchema_Code, IncludeDisclosurePopList_Code FROM StaticDataDepot.LRDW_Reference_Data.ReportType) src
ON tgt.ReportType_BK = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (ReportType_BK, CalculationActiveIndicator_Code, StartDate, EndDate, MaturitySchema_Code, IncludeDisclosurePopList_Code, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, CalculationActiveIndicator_Code, StartDate, EndDate, MaturitySchema_Code, IncludeDisclosurePopList_Code, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_ReportType', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_ReportType;

-- ReportingEntityReportTypeMapping
DELETE FROM LRDW_DataVault.LrdwVault.R_ReportingEntityReportTypeMapping

MERGE INTO LRDW_DataVault.LrdwVault.R_ReportingEntityReportTypeMapping tgt
USING (SELECT Code, ReportingEntity_Code, ReportType_Code, StartDate, EndDate FROM StaticDataDepot.LRDW_Reference_Data.ReportingEntityReportTypeMapping) src
ON tgt.ReportingEntityReportTypeMapping_BK = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (ReportingEntityReportTypeMapping_BK, ReportEntity_Code, ReportType_Code, StartDate, EndDate, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, ReportingEntity_Code, ReportType_Code, StartDate, EndDate, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_ReportingEntityReportTypeMapping', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_ReportingEntityReportTypeMapping;

-- SocialEconomicBalance
DELETE FROM LRDW_DataVault.LrdwVault.R_SocialEconomicBalance

MERGE INTO LRDW_DataVault.LrdwVault.R_SocialEconomicBalance tgt
USING (SELECT Code, Name, InstitutionalSector_Code FROM StaticDataDepot.LRDW_Reference_Data.SocialEconomicBalance) src
ON tgt.SebCode = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (SebCode, SebCodeDescription, InstitutionalSector, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, Name, InstitutionalSector_Code, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_SocialEconomicBalance', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_SocialEconomicBalance;

-- StatusTypeUsageMapping
DELETE FROM LRDW_DataVault.LrdwVault.R_StatusTypeUsageMapping

MERGE INTO LRDW_DataVault.LrdwVault.R_StatusTypeUsageMapping tgt
USING (SELECT Code, Status_Code, Usage_Code, SortOrder, Active_Code FROM StaticDataDepot.LRDW_Reference_Data.StatusTypeUsageMapping) src
ON tgt.StatusTypeUsageMapping_BK = src.Code
WHEN NOT MATCHED
	THEN
		INSERT (StatusTypeUsageMapping_BK, Status_Code, Usage_Code, SortOrder, Active_Code, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, Status_Code, Usage_Code, SortOrder, Active_Code, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_StatusTypeUsageMapping', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_StatusTypeUsageMapping;

-- TradingLocation
DELETE FROM LRDW_DataVault.LrdwVault.R_TradingLocation

MERGE INTO LRDW_DataVault.LrdwVault.R_TradingLocation tgt
USING (SELECT Code, OriginatingEntity_Code FROM StaticDataDepot.LRDW_Reference_Data.TradingLocation) src
ON tgt.TradingLocation_Code = src.Code AND tgt.OriginatingEntity_Code = src.OriginatingEntity_Code
WHEN NOT MATCHED
	THEN
		INSERT (TradingLocation_Code, OriginatingEntity_Code, LoadDate, LoadEndDate, ProcessLogSeqID)
		VALUES (src.Code, OriginatingEntity_Code, GETUTCDATE(), '99991231', 1);

INSERT INTO @RecordCounts (TableName, RecordCount) SELECT 'R_TradingLocation', COUNT(*) FROM LRDW_DataVault.LrdwVault.R_TradingLocation;

SELECT TableName, RecordCount FROM @RecordCounts;